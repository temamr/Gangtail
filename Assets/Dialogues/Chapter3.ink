VAR CharacterName = ""
VAR TurtleEmotion = 0
VAR KunitsaEmotion = 16
(Пыль, летающая в зоздухе не давала Рикки нормально дышать)
(Сквозь кашель, Рикки с грустью осознал)
~CharacterName = "Рики"
Вот блин… Думали, проскользнем незаметно?  

~KunitsaEmotion = 0
~CharacterName = ""
~KunitsaEmotion = 9
(Прижавшись к стене, Лекса охватил страх, он резко оглядывается по сторонам)
~CharacterName = "Лекс"
Нет, просто взорвали не ту стену!  

~KunitsaEmotion = 21
~CharacterName = ""
(Дейв, скрестви руки, быстро дал команду)
~CharacterName = "Дейв"
Спокойно. Меган, видимо, здесь нет
~KunitsaEmotion = 1
(Как скомандуешь?)
    +[нам нужно сматываться!]
        ->answer1
    +[мы будем сражаться]
        ->answer2

=== answer1 ===
~KunitsaEmotion = 3
~CharacterName = "Главный"
Быстро, сматываемся! Они нас заметят
~KunitsaEmotion = 18
~CharacterName = "Дейв"
Уже нет времени, мы все УМРЁМ!
->Fight
->END

=== answer2 ===
~KunitsaEmotion = 3
~CharacterName = "Главный"
Всем приготовиться к бою, мы защитим себя!
->Fight
->END

=== Fight ===
~KunitsaEmotion = 0
~TurtleEmotion = 10

~CharacterName = ""
(Внезапно — удар по нервам: Леонардо выскакивает из тени, его меч блестит, будто только из ножниц Адской кухни) 
(Он атакует без промедления — мгновение, и пространство взрывается движением)
~KunitsaEmotion = 9
~CharacterName = "Лекс"
Сза—!
~KunitsaEmotion = 8
~CharacterName = ""
(Лезвие рассеивает воздух, как кипяток паутину. Лекс срывается с ног, падает навзничь, глаза закатываются)

~KunitsaEmotion = 11
~TurtleEmotion = 0
~CharacterName = "Рики"
Ты, зеленая тварь!
~CharacterName = ""
~TurtleEmotion = 5
(Но из правого фланга, как змея из ямы, появляется Рафаэль)
~TurtleEmotion = 6
~KunitsaEmotion = 0
(Его сай блестит смертельной дугой, вонзается в бок Рики. Тело Рикки исчезло)
~TurtleEmotion = 0
~KunitsaEmotion = 20
~CharacterName = "Дейв"
Нас слишком мало…
~TurtleEmotion = 0
(На заднем плане шорох — что-то приближается. Дейв бросает взгляд за спину, в сторону игрока)
~KunitsaEmotion = 18
~CharacterName = "Дейв"
Главный, беги!!!
~CharacterName = ""
~TurtleEmotion = 19
(Микеланджело ударяет Дейва нунчаками. Хруст. Падение)
~KunitsaEmotion = 22
(Вокруг море крови, тела куниц лежат на полу без движений, ужас поразил Главного)
~TurtleEmotion = 0
~KunitsaEmotion = 2
(Жив остался только Главный. Донателло и Рафаэль выходят из тени)
~KunitsaEmotion = 1
(Игрок достает пистолет)
    +[Убить Донателло]
        ->DonatelloKilled
    +[Убить Рафаэля]
        ->RafKilled
->END

=== DonatelloKilled ===
(Пуля со свистом вылетает из дула ствола и попадает прямр в голову Донателло)
->EndOfFight

=== RafKilled ===
(Громкий выстрел оглушил всех в комнате. Когда все пришли в сознание, увидели Рафа, тело которго лежало на холодном палу. Он был убит пулей в грудь)
->EndOfFight

=== EndOfFight ===
~KunitsaEmotion = 2
(От испуга Герой потерял дар речи, он не собирался никого убивать. Сердце забилось сильнее. Оставалось только бежать)
->END