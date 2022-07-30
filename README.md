# FileSortingCore
## Оглавление 
1. [Цель проекта](#ProjectGoals)
2. [Элементы библиотеки](#LibraryElements)
    + [Класс FilesSorting](#FilesSorting)
    + [Интерфейс ISortingConfig](#ISortingConfig)
    + [Класс StandartConfig](#StandartConfig)
    + [Перечисление ChangeNameState](#ChangeNameState)
    + [Интерфейс ILogger](#ILogger)
    + [Класс DebugLogger](#DebugLogger)
    + [Класс NameTakenException](#NameTakenException)
3. [Примеры реалезации библиотеки](#LibraryExamples)
4. [Свойства проекта](#ProjectProperties)

## Цели проекта <a name="ProjectGoals"></a>
Предоставить пользователю

* встраиваемую библиотеку для использования в своих проектах
* Настраиваемый процесс сортировки

## Элементы библиотеки <a name="LibraryElements"></a>

### Класс FilesSorting <a name="FilesSorting"></a>
Главный класс библиотеки. Находтися в пространсве именн имен FileSorting.Core

#### Конструкторы 
Имеет 2 конструктор

* FilesSorting(ISortingConfig config, ILogger log)  
config -  класс конфигурации реалезующий интерфейс ISortingConfig,  
log - класс для вывода информации хода работы реалезующий интерфейс ILogger
*  public FilesSorting(ISortingConfig config)  
config -  класс конфигурации реалезующий интерфейс ISortingConfig,

#### Методы
* void StartMovingFile()  
Начитанает сортировку файлов

### Интерфейс ISortingConfig <a name="ISortingConfig"></a>
Нужен для создания различный реалезаций своих конфигурации. Находтися в пространсве имен FileSorting.Core.Configs

#### Свойства

* string SortingPath  
Содержит в себе путь к папке в которой нужно отсортировать
* ChangeNameState ChangeState
Сожержит в себе состояние которое будет реалезоваться при файлы в папку с занятым именем

### Класс StandartConfig <a name="StandartConfig"></a>
Реалезация интерфейса ISortingConfig, имеет настройку свойств с помощью атрибута JsonPropertyName и конструктор которые принимают все пораметры для заполнения свойств ISortingConfig. Находтися в пространсве имен FileSorting.Core.Configs

### Перечисление ChangeNameState <a name="ChangeNameState"></a> 
Перечисления состояний перемещения файлы. Отчет свойсв начинается с 1. Находтися в пространсве имен FileSorting.Core.Configs

* Exception
* Change
* Ignoring

### Интерфейс ILogger <a name="ILogger"></a>
Нужен для создания различный реалезаций отоброжения хода работы. Находтися в пространсве имен FileSorting.Logging

#### Методы

* void InfoLog(string message)  
message - строка которая будет выведена в вашей реалезации ILogger

* void ErrorLog(string message)  
message - строка которая будет выведена в вашей реалезации ILogger

### Класс DebugLogger <a name="DebugLogger"></a>
Реалезация интерфейса ILogger, выводит полученные сообщения с помощью статического класса Debug. Находтися в пространсве имен FileSorting.Logging.SpecificLogger

### Класс NameTakenException <a name="NameTakenException"></a>
Класс ошибки вызываемой при ChangeNameState.Exception и уже имеющемся файле с таким именем в папке. Находтися в пространсве имен FileSorting.Core.Exceptions

#### Конструкторы 
* NameTakenException(FileInfo file, string? message)  
file - файл в котором была вызвана ошибка
message - текст ошибки
* NameTakenException(FileInfo file)  
file - файл в котором была вызвана ошибка

#### Свойства 
* FileInfo File  
Содержит в себе файл в котором произошла ошибка

## Примеры реалезации библиотеки <a name="LibraryExamples"></a>
* [Консольный приложение](https://github.com/Ang2Tea/FileSortingConsole)

## Свойства проекта <a name="ProjectProperties"></a>
 Проетк реалезован на C# 10, платформа .NET 6
