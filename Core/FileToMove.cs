using FileSorting.Core.Configs;
using FileSorting.Core.Exceptions;

namespace FileSorting.Core
{
    internal class FileToMove
    {
        private readonly string fileNameOnly;

        public FileInfo ChangeFile { get;  init; }
        public string CurrentPath { get; set; }
        public bool DirectoryExists { get => Directory.Exists(CurrentPath); }
        public bool FileExists { get => ChangeFile.Exists; }

        public event Action<string>? IgnoreChangeName;

        public FileToMove(string mainDirectory, FileInfo currentFile)
        {
            ChangeFile = currentFile;
            fileNameOnly = ChangeFile.Name.Split(".")[0];
            CurrentPath = mainDirectory + "\\" + ChangeFile.Extension[1..].ToUpper();
        }

        private bool MovedFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                ChangeFile.MoveTo(filePath);
                return true;
            }
            return false;
        }
        public void MovingFile(ChangeNameState changeName)
        {
            string currentFilePath = CurrentPath + "\\" + ChangeFile.Name;

            for (int i = 1; !MovedFile(currentFilePath); i++)
            {
                switch (changeName)
                {
                    case ChangeNameState.Exception: throw new NameTakenException(ChangeFile, $"File {ChangeFile.Name} already exists in the correct directory");
                    case ChangeNameState.Ignoring:
                        {
                            IgnoreChangeName?.Invoke($"File {ChangeFile.Name} already exists in the correct directory");
                            return;
                        }
                    case ChangeNameState.Change:
                        {
                            currentFilePath = CurrentPath + "\\" + fileNameOnly + $"({i})" + ChangeFile.Extension;
                            break;
                        }
                }
            }
        }
    }
}
