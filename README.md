# RecipeCook.TelegramBot

<p>
<img src="https://yandex-images.clstorage.net/e4Dk8e221/1d89b6_1/GgAARen-IO6qielWpJIf-fSI57W_8ap0lvf7uowEnh7ISIIlrqlE8Ke9LnDogHlpoG4IaMw_HXOUGA0twmwKVTgV0lM936AuidopMqAj6q1FTDcGXOP4NzHl6MlahnyuHIjyte9d9OUkfvrhnCcsrLRqXwxI7Pu0h89sDAKdveXaQHPzzSgj75gqOAckpd2I9Qxm5p2B2JYyNZkqqrXO7Q-pUATcGcbUxK0vkL7FzU21274fK27oplWsHd0QHAxGqQBA0r8a895aSTt1NcWea4XcZuTMg3hGAYeomyqVnA7OKpHE7qn1VLd9rFOtZd0ONGvPP9jdyiWWTexugHwNlWsz8SINmoINeAgbx3XWj8sFrye3PHDYtGEmaOjq1C6u_BpCJ6x4RTUl701hXxRcL9XJfwyKDAqmdP28jICOXDR7cWNS3_rjnfk72_fVFh_pFW43tK1D2FRBlStI6LQO3r6KkJYvupTGpy3vcU0XPI_l290PCB5px8WMnMxyz-2ku_GDw11a4J3aS7nWp8bt6oWuRxX8IRrmkJZ7CJl3rw28-3B1X5tHhmXfLpDetdy_d6l8DQheGPVUrkw-Mo8s9JkDw0M8adDOmFsIZbQGfUrGPLclvHO6t2DUGWhKhY3eLcigFL3KNKSn3I_wbtX9TCfJPc-6HKhHRw5N_yLMfTc78fERDSry3vupmVXHN304l04lhJ4RmIayJ9toWBffHf5bUaWsieS0lA9MUZ92HA7XG-8sScz55ha_3j5xLl5GyXNiUL07gdyICPpXVxavSyfvlJaOgcj30oZ4aEolvs0Nu1Nk3Pt2xiS_j7NcVw1ttavPTbpvq_TErh7cUw4s1fuCQFDvq_B9aNv4BrSUTWs0zud37YMLB7FnWchIVHwf7Rlz5Q7pd2Uknm6Q3RZerUa53a9pTBr0t6xOnhIcDgbIM-HQ34ogrYjaSYbV9Gwo9q6XZC2gqofTtIpJicZOE" width="125" title=RecipeCook Telegram bot's logo">
</p>

## Основная информация
Бот создан с целью ознакомления с [C# Telegram Bot API](https://github.com/TelegramBots/Telegram.Bot). Его основная задача - поиск рецепта блюда по его названию, а также предложение случайного рецепта. База данных с рецептами - [Spoonacular API](https://spoonacular.com/food-api).

### [Ссылка на бота](https://t.me/RecipeCook_bot)

### <b>Важное примечание:</b> бот не работает в данный момент, поскольку он не задеплоен куда-либо. Вы можете самостоятельно захостить его на собственном компьютере с помощью консольного приложения.

## Процесс хостинга бота
Для того, чтобы захостить бота, вам требуется либо запустить его через проект в Visual Studio, либо опубликовать в папку и запустить exe файл.
Консоль выведет версию бота и его токен.
Для запуска работы бота требуется написать "/start", а чтобы в любой момент отключить бота - написать "/stop".

Если пользователь напишет сообщение в бот, то в косноли выведется информация о пользователе, его сообщение, а также логи выполнения команды.

## Команды бота
<li>Любое название блюда - производит поиск блюда по названию</li>
<li>/random - выдаёт случайный рецепт</li>
<li>/getinfo - выдаёт информацию о боте и ссылки на API</li>
<li>/easteregg - пасхалка</li>
