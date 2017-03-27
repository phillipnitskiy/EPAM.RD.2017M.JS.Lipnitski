# EPAM.RD.2017M.JS.Lipnitski

- [ ] У каждого будет тематический сайт. Тема сайта должна быть уникальна.
1.	Меню навигации должно быть под шапкой сайта.
    1. При наведении на пункт, должен появляться блок с подпунктами (выподащее меню)
2.	В шапке сайта должно быть либо привественное сообщение с именем пользователя, либо форма для логина
3.	На главной странице должно находиться текстовое описание сайта и его темы, а так же ТОП 3 альбома.
4.	Если пользователь залогинен как администратор, на главной странице сайт должна быть активна кнопка редактирования описания сайта.
    1.	Поле редактирование тесктового описание сайта должно повляться на месте текста
5.	В текстовом описании должна быть возможно использовать механику Спойлеров (скрывать и разворачивать блоки по нажатию)
6.	Должна быть возможность помечать термины. При наведении на них должна появляться всплывающая подсказка с определение термина
- [ ] На сайте должна быть отдельная страница с галереей посвящённой теме сайта.
7.	- [x] В галерею, картинки должны подтягиваться через сервис (речь о Angular service).
8.	В первоначальном состоянии галерея должна содержать превью картинок.
    1.	По клику на превью выбранное изображение должно быть выведено в полном разрешении.
    2.	При клике на полноформатное изображение, картинка должна вернуться к прежнему состоянию превью
9.	На странице должны быть checkbox со всеми используемыми в галерее форматами, например, png, jpg. В галерее должны быть видны лишь те картинки которые удовлетворяют выбранным форматам
10.	- [x] Над картинкой должно быть выведено её название
11.	- [x] Под картинкой должна отображаться оценка картинки и дата её создания
12.	- [x] Любой, в том числе незарегестрированный пользователь должен иметь возможно оставить поставить картинке оценку
13.	- [x] Над галлерей должен быть dropdown со списком альбомов
    1. - [x] Среди прочих альбомов должна быть опция показать всё
- [ ] На сайте должна быть отдельная страница для добавления новой картинки
14.	- [x] На странице должна быть форма с полями Url, название, описание и начальная оценка, дата публикации картинки, альбом назначения
15.	- [x] По ходу заполенения полей, в правой части экрана должна заполняться превью картинки.
16.	При добавлении картинки пользователем не обладающим правами moderator, она не должна появляться в общем спике картинок. Лишь после перевода картинки в состояние Проверена (это делает moderator) картинка будет видна в галерее.
17.	- [x] Если у картинки используется ранее не известный формат, опция с фильтром под новый формат должна появляться автоматически
- [ ] На сайте должна быть страница доступная только модераторам
18.	На странице должен быть список картинков ожидающих проверки.
    1.	Картинку можно перевести в состояние Подтверждена. Тогда она будет доступна для просмотра на странице галерее
    2.	Если Картинка переведена в состояние Отклонена, данные о ней должы быть удалены
- [ ] Так же должны быть выполненные следующие технические требования:
19.	Адаптивная вёрстка на разрешениях от 800px до 1980px
20.	e2e тесты для проверки основного функционала
