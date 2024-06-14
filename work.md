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
    actor DiscordServer
    
    rectangle Bot{
        usecase SendTask
        usecase Polling
        usecase GetTask
    }

    TaskGiver -- SendTask
    Executor -- GetTask
    SendTask -- DiscordServer
    GetTask -- DiscordServer
    SendTask --> Polling
    Polling --> GetTask

@endmul
```
```plantuml
@startuml Components1
    Title Components 
    package "Bot"{
        [CommandReader]
        [CommandProcessor]
        [PollingSystem]
        [OutputSystem]
        [Storage]
    }

    [CommandReader] --> [CommandProcessor] 
    [CommandProcessor] --> [PollingSystem]
    [OutputSystem] --> [CommandProcessor]
    [Storage] --> [PollingSystem]

@enduml
```

```plantuml
@startuml State
Title State bot?

Initialization : Enrty / LoadConfig
Initialization : Connect / Connection

[*] --> Initialization
Initialization --> WaitingCommand : Init / Load Config
WaitingCommand --> CreateTask : InputCommand / Create Task
CreateTask --> PollingExecutor : Created / Start polling
PollingExecutor --> WaitingCommand : NotFound / Reject
UpdateStatus --> WaitingCommand : TaskCompleted
WaitingCommand --> SendStatusResult : InputCommand / Send Status
SendStatusResult --> WaitingCommand : StatusSended
PollingExecutor --> UpdateStatus : ExecutorFinded
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