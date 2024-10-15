
# Ресторанное дело
Описание: данный проект представляет собой веб-приложение, которое позволяет пользователям просматривать информацию о ресторане (меню, контактные данные ресепшена, адрес, рабочий график), регестрироваться/заходить в учётную запись, оформлять заказы и предзаказы и добавлять в избранное понравившиеся позиции в меню.
## Функциональные требования

### 1. Регистрация пользователя
- Пользователь должен иметь возможность создать учетную запись, введя:
  - Имя пользователя
  - Адрес электронной почты
  - Пароль
- После успешной регистрации пользователь должен получать уведомление и перенаправление на страницу логина.

### 2. Логин и логаут пользователя
- Пользователь должен иметь возможность войти в систему, введя свой адрес электронной почты и пароль.
- При успешном входе пользователь должен быть перенаправлен на главную страницу.
- Пользователь должен иметь возможность выйти из системы в любое время.

### 3. (INDEX) Просмотр списка записей заказов и предзаказов, а также избранные блюда
- После входа в систему пользователь должен видеть список всех своих записей, с возможностью:
  - Просмотреть основные данные о каждой записи заказа(заголовок, дата создания).
  - Перейти к деталям заказа.
  - Посмотреть в отедльной вкладке список избранных блюд и перейти к конкретному избранному блюду.
    

### 3. (INDEX) Просмотр списка заказов и избранных блюд
- После входа в систему пользователь должен видеть список всех своих записей заказов и предзаказов, с возможностью:
  - Просмотреть основные данные о каждом заказе (заголовок, дата создания).
  - Перейти к деталям заказа.
  - Посмотреть в отдельной вкладке список избранных блюд и перейти к конкретному избранному блюду.

### 4. (CREATE) Создание записи заказа или предзаказа
- Пользователь должен иметь возможность создать новый заказ или предзаказ, заполнив форму, в которой необходимо указать:
  - Заголовок заказа
  - Содержимое заказа (например, список блюд, количество)
  - Теги (по желанию)
- После успешного создания заказа пользователь должен быть перенаправлен на страницу просмотра списка заказов и предзаказов.

### 5. (READ) Просмотр деталей заказа
- Пользователь должен иметь возможность кликнуть на заказ из списка и просмотреть его детали, включая:
  - Заголовок
  - Содержимое
  - Дата создания
  - Теги (если указаны)

### 6. (UPDATE) Редактирование заказа
- Пользователь должен иметь возможность редактировать существующий заказ.
- На странице редактирования заказа должны быть заполнены предыдущие данные, которые пользователь может изменить.
- После успешного редактирования пользователь должен быть перенаправлен обратно на страницу списка заказов и предзаказов с уведомлением об успешном обновлении.

### 7. (DELETE) Удаление заказа
- Пользователь должен иметь возможность удалить заказ из списка.
- При удалении заказа должно появляться подтверждающее окно.
- После успешного удаления пользователь должен получать уведомление о том, что заказ был удалён.

### Управление избранными блюдами
- Пользователь должен иметь возможность добавлять блюда в список избранных.
- Пользователь должен иметь возможность удалять блюда из избранного.
- Избранные блюда должны быть доступны на отдельной вкладке.

## Нефункциональные требования для пользователей
- Приложение должно быть доступно на веб-платформе.
- Должны быть предусмотрены меры безопасности для защиты данных пользователей.
- Интуитивно понятный интерфейс и простота использования.

## Функциональные требования для администратора
### 1. (CREATE) Добавление нового блюда в меню
- Администратор должен иметь возможность создать новое блюдо, введя следующие данные:
  - Название блюда
  - Описание блюда
  - Цена блюда
  - Категория блюда (например, закуски, основные блюда, десерты и т. д.)
  - Изображение блюда (опционально, но рекомендуется для лучшего восприятия)
- После успешного создания блюда администратор должен получать уведомление и перенаправление на страницу просмотра списка доступных блюд.

### 2. (READ) Просмотр списка блюд в меню
- Администратор должен иметь возможность просматривать все блюда, доступные в меню, с основными данными:
  - Название блюда
  - Цена
  - Категория
  - Возможность просмотра изображения
- Должна быть возможность перейти к деталям каждого блюда.

### 3. (UPDATE) Редактирование блюда
- Администратор должен иметь возможность редактировать существующее блюдо.
- На странице редактирования блюда должны быть предзаполнены предыдущие данные, которые администратор может изменить.
- После успешного редактирования администратор должен быть перенаправлен обратно на страницу списка блюд с уведомлением об успешном обновлении.

### 4. (DELETE) Удаление блюда из меню
- Администратор должен иметь возможность удалить блюдо из списка.
- При удалении блюда должно появляться подтверждающее окно для предотвращения случайной потери данных.
- После успешного удаления администратор должен получать уведомление о том, что блюдо было удалено.

### 5. Вывод информации о блюде
- При выборе блюда из списка администратор должен иметь возможность видеть детальную информацию о нем, включая:
  - Название
  - Описание
  - Цена
  - Категория
  - Изображение (если было добавлено)

### 6. Управление категориями блюд
- Администратор должен иметь возможность добавлять, редактировать и удалять категории блюд, чтобы поддерживать структурированность меню.

## Нефункциональные требования для администратора
- Должны быть предусмотрены меры безопасности для предотвращения несанкционированного доступа к административной части приложения.
- Интерфейс для администратора должен быть интуитивно понятен и удобен в использовании.

## Проектная база
<img width="847" alt="Снимок экрана 2024-10-15 в 23 10 37" src="https://github.com/user-attachments/assets/1e175557-9f86-4086-89b4-5b21b96df5b5">





