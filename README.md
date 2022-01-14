# UltimateTests
## Задача: 
Разработать систему тестирования студентов колледжа, которая позволяет студентам проходить тесты, а преподавателям назначать тесты для студентов и отсматривать их результаты.
<br>
### Вопросы в тестах могут представляться в одном из трех видов: 
:white_check_mark: Вопрос с выбором одного ответа 
<br> :white_check_mark: Вопрос с выбором нескольких ответов 
<br> :white_check_mark: Вопрос с вводом ответа 

### Для тестов:
:white_check_mark: Система тегов, для упрощения поиска преподавателями 
<br> :white_check_mark: Сохраняется время, за которое студент выполнил тест

### Тестестирование слоёв:
:white_check_mark: Логика
<br> :white_check_mark: Слой Данных / БД


## <br> Пользователи и их функционал:
### Администратор:
:white_check_mark: Создание/удаление/редактирование пользователей
<br> :white_large_square: Создание/удаление/редактирование групп
<br> :white_large_square: Добавление/удаление преподавателей и студентов для группы

### Методист/ Автор тестов:
:white_large_square: Создание/удаление/редактирование тестов
<br> :white_large_square: Создание/удаление/редактирование вопросов к тестам
<br> :white_check_mark: Просмотр статистики по тестам для всех студентов и групп
<br> :white_large_square: Пробное прохождение тестов (с выводом результата но без сохранения статистики)
<br> :white_large_square: Просмотр фидбэка к тестам

### Преподаватель:
:white_large_square: Назначение теста для группы со сроком выполнения
<br> :white_large_square: Просмотр результатов/статистики студентов своих групп
<br> :white_large_square: Просмотр вопросов/тестов
<br> :white_large_square: Пробное прохождение тестов
<br> :white_large_square: Возможность оставлять фидбэк к тестам (например нашел ошибку в тесте)

### Студент:
:white_large_square: Просмотр списка активных тестов
<br> :white_large_square: Прохождение тестов
<br> :white_large_square: Просмотр своих результатов/статистики
<br> :white_large_square: Возможность оставлять фидбэк к тестам
