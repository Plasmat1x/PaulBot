# PaulBot
<!-- TOC -->

- [PaulBot](#paulbot)
    - [Задача](#%D0%B7%D0%B0%D0%B4%D0%B0%D1%87%D0%B0)
        - [Постановка](#%D0%BF%D0%BE%D1%81%D1%82%D0%B0%D0%BD%D0%BE%D0%B2%D0%BA%D0%B0)
        - [Требуется](#%D1%82%D1%80%D0%B5%D0%B1%D1%83%D0%B5%D1%82%D1%81%D1%8F)
            - [Формирование документации описание](#%D1%84%D0%BE%D1%80%D0%BC%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5-%D0%B4%D0%BE%D0%BA%D1%83%D0%BC%D0%B5%D0%BD%D1%82%D0%B0%D1%86%D0%B8%D0%B8-%D0%BE%D0%BF%D0%B8%D1%81%D0%B0%D0%BD%D0%B8%D0%B5)
            - [Подготовьте каркас приложения - работающее поведение, без самих исполнительных блоков - операций;](#%D0%BF%D0%BE%D0%B4%D0%B3%D0%BE%D1%82%D0%BE%D0%B2%D1%8C%D1%82%D0%B5-%D0%BA%D0%B0%D1%80%D0%BA%D0%B0%D1%81-%D0%BF%D1%80%D0%B8%D0%BB%D0%BE%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F---%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%D1%8E%D1%89%D0%B5%D0%B5-%D0%BF%D0%BE%D0%B2%D0%B5%D0%B4%D0%B5%D0%BD%D0%B8%D0%B5-%D0%B1%D0%B5%D0%B7-%D1%81%D0%B0%D0%BC%D0%B8%D1%85-%D0%B8%D1%81%D0%BF%D0%BE%D0%BB%D0%BD%D0%B8%D1%82%D0%B5%D0%BB%D1%8C%D0%BD%D1%8B%D1%85-%D0%B1%D0%BB%D0%BE%D0%BA%D0%BE%D0%B2---%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B9)
            - [Подготовьте тесты каркаса.](#%D0%BF%D0%BE%D0%B4%D0%B3%D0%BE%D1%82%D0%BE%D0%B2%D1%8C%D1%82%D0%B5-%D1%82%D0%B5%D1%81%D1%82%D1%8B-%D0%BA%D0%B0%D1%80%D0%BA%D0%B0%D1%81%D0%B0)
            - [Цели](#%D1%86%D0%B5%D0%BB%D0%B8)
            - [Способ организации работы](#%D1%81%D0%BF%D0%BE%D1%81%D0%BE%D0%B1-%D0%BE%D1%80%D0%B3%D0%B0%D0%BD%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D0%B8-%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D1%8B)
            - [Ожидаемый результат](#%D0%BE%D0%B6%D0%B8%D0%B4%D0%B0%D0%B5%D0%BC%D1%8B%D0%B9-%D1%80%D0%B5%D0%B7%D1%83%D0%BB%D1%8C%D1%82%D0%B0%D1%82)
            - [Срок](#%D1%81%D1%80%D0%BE%D0%BA)
            - [Форма](#%D1%84%D0%BE%D1%80%D0%BC%D0%B0)
            - [Рекомендации](#%D1%80%D0%B5%D0%BA%D0%BE%D0%BC%D0%B5%D0%BD%D0%B4%D0%B0%D1%86%D0%B8%D0%B8)
                - [PS](#ps)
    - [Рабочее](#%D1%80%D0%B0%D0%B1%D0%BE%D1%87%D0%B5%D0%B5)

<!-- /TOC -->
<!-- /TOC -->

## Задача

### Постановка
Тема задачи: `Discord бот, задача которого - поиск исполнителей задач`

Например боту приходит задание: 
`Я Вася - Васечкин, у меня есть задача X, хочу найти, кто ее сможет сделать. Срок - 30 мин.`

Бот дает заданию номер и приступает к работе. Вероятно у бота можно узнать статус задачи. 
Также, вероятно, бот может сообщить, исполнитель найден или нет.
Что не известно - сами придумайте или додуамйте.

Отправка заданий боту, может делаться например через `Discord Guild` команды.

### Требуется
#### Формирование документации (описание)
1. общие требования и ограничения на систему, по типу мне надо так-то, для того, чтобы…
2. роли и прецеденты
3. сценарии использования
4. описание основных компонентов системы
5. описать состояния компонентов, режимы работы , этапы

Попробуйте сформировать - описать вашей системы в понятном для другого человека виде.

####  Подготовьте каркас приложения - работающее поведение, без самих исполнительных блоков - операций;
#### Подготовьте тесты каркаса.
xUnit

#### Цели
* тренировка аналитики и декомпозиции;
* отработка навыка построения каркаса приложения, без использования реальных служб (Discord, DB, Queue и прочее);
* отработка навыков написания тестов;
* слаживание.

#### Способ организации работы
* точить в один хоббот
* сколотить шайку
* толпа
ограничений нет, все или ничего. важен только результат

#### Ожидаемый результат
* получения материала для оценки фактических навыков;
* оценка аналитических способностей;
* оценка ролей (Хиллер, Дамагер, Танк);
* оценка коммуникационных паттернов.

#### Срок
понедельник, конец дня.

#### Форма
ссылка на git репозиторий с историей, не забываем gitignore, и четкие коммиты, если конечно вы не бруском делать будете.

#### Рекомендации
сами составили вопросы - сами ответили. интерфейсы - ключ для кооперативной разработки. 3 tier architecture. Часть тестов вперед. Декомпозиция + состояния.

##### PS
нужны доки и макет и тесты, глубину вы сами регулируете

[Additional.md](./Additional.md)

## Рабочее

[work.md](./work.md)
