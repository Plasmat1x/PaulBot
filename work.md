# Записи, Идеи и тд

## Требования

### Сценарий

1. пользователь с задачей пишет в `дискорд` задачу `командой`
2. `дискорд` отправляет задачу в `бота`
3. `бот` ставит идентификатор задаче
4. `бот` опрашивает исполнителей
   *  A. `бот` отправляет личным сообщением всем исполнителям
   *  B. `бот` отправляет в общий канал задачу
   *  C. `бот` применяет алгоритм и сам назначает исполнителя
5. исполнители принимают `командой`
6. кто первый принял того бот ставит на исполнение и заносит в `хранилище`

#### возможные проблемы
* 4.A 
  * Преймущества: Быстрый поиск исполнителей, приватность
  * Недостатки: Спам, необходимость разрешить конфликты, управление и мониторинг
  * Применение: Мало исполнителий, не частые задачи
* 4.B
  * Преймущества: Прозрачно, легко управлять
  * Недостатки: Приватность
  * Применение: Необходимо что бы были видны задачи, Частота и оперативность
* 4.C
  * Преймущество: Контроль распределения, Без конкуренций, расчет нагрузки исполнителей
  * Недостатки: Справедливый и эффективный алгоритм, исполнитель может быть не готов к моменту назначения, ошибки при назначениях
  * Применение: при возможности и знания занятости исполнителей, важно равномерное распределение задач, когда задачи требуют специфически навыков 



---
## Диагрмаки
```plantuml
@startuml UseCase
    Title Usecase
    left to right direction

    actor TaskGiver
    actor Executor
    actor Administrator
    
    rectangle Bot{
        usecase SendTask
        usecase Polling
        usecase ProcessTask
        usecase GetTask
        usecase ReadLog
    }

    TaskGiver -- SendTask
    Executor -- GetTask
    SendTask --> ProcessTask : include
    ProcessTask --> Polling : include 
    Executor -- Polling
    Administrator -- ReadLog

@endmul
```
```plantuml
@startuml Components1
    Title Components

    package "Presenter"{
        [CommandReader]
        [OutputSystem]
    }

    package "Logic"{
        [ICommandReader]
        [IOutputSystem]
        [CommandProcessor]
        [IPollingSystem]
        [IStorage]
        [TaskProcessor]
    }

    package "Infrastructure"{
        [Storage]
    }

    package "PollingSystem"{
        [ChannelMessage]
        [PersonalMessage]
        [AssignAlgorithm]
    }

    [CommandReader] --> [ICommandReader]
    [OutputSystem] --> [IOutputSystem]

    [ICommandReader] --> [CommandProcessor] 
    [IOutputSystem] --> [CommandProcessor]
    [CommandProcessor] --> [TaskProcessor]
    [IPollingSystem] --> [TaskProcessor]
    [IStorage] --> [IPollingSystem]
    [IStorage] --> [TaskProcessor]

    [ChannelMessage] --> [IPollingSystem]
    [PersonalMessage] --> [IPollingSystem]
    [AssignAlgorithm] --> [IPollingSystem]

    [Storage] --> [IStorage]

@enduml
```

```plantuml
@startuml State
Title State bot?

Initialization : Enrty / LoadConfig
Initialization : Connect / Connection

[*] --> Initialization
Initialization --> WaitingCommand : Init / Load Config

WaitingCommand --> ProcessTask : TaskCommand / CreateTask
WaitingCommand --> ProcessTask : StatusCommand / GetTaskStatus
SendStatusResult --> WaitingCommand : StatusSended
ProcessTask --> CheckTask : SendTaskStatus
CheckTask --> SendStatusResult : GetTaskStatus
ProcessTask --> CreateTask : TaskCreation
CreateTask --> ProcessTask : TaskCreated
UpdateStatus --> ProcessTask : TaskCompleted
ProcessTask --> WaitingCommand : TaskCompleted
ProcessTask --> UpdateStatus : ExecutorFinded / TaskStatusNotCompleted
ProcessTask --> UpdateStatus : ExecutorNotFinded / TaskStatusCompleted
ProcessTask --> PollingExecutor : Created / Start polling

WaitingCommand --> Exit : Exit
Exit --> [*]
@enduml
```

```plantuml
@startuml
Title States of Task

state Searching
state Pending
state Completed

[*] --> Searching
Searching --> Pending: AssignExecutor
Pending --> Completed: CompleteTask
Completed --> [*]

@enduml
```