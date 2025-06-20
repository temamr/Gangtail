VAR CharacterName = ""
VAR TurtleEmotion = 0
VAR KunitsaEmotion = 16
Пыль, летающая в воздухе, не давала Рикки нормально дышать.
VAR Music = 5
Сквозь кашель Рикки с грустью осознал:
~CharacterName = "Рикки"
~Music = 13
Вот блин... Думали, проскользнем незаметно?

~KunitsaEmotion = 0
~CharacterName = ""
~KunitsaEmotion = 9
~Music = 15
Прижавшись к стене, Лекса охватил страх, он резко огляделся по сторонам.
~CharacterName = "Лекс"
Нет, просто взорвали не ту стену!

~KunitsaEmotion = 19
~CharacterName = ""
Дейв, скрестив руки, стал успокаивать команду:
~CharacterName = "Дейв"
Спокойно. Меган, видимо, здесь нет.
~CharacterName = ""
~KunitsaEmotion = 1
Что будем делать?
    +[Нам нужно сматываться!]
        ->answer1
    +[Мы будем сражаться]
        ->answer2

=== answer1 ===
~KunitsaEmotion = 3
~CharacterName = "Главный"
Быстро, сматываемся! Они нас заметят.
~KunitsaEmotion = 18
~CharacterName = "Дейв"
Уже нет времени, ЗАЩИЩАЙТЕСЬ!
->Fight
->END

=== answer2 ===
~Music = 12
~KunitsaEmotion = 3
~CharacterName = "Главный"
Всем приготовиться к бою!
->Fight
->END

=== Fight ===
~KunitsaEmotion = 0

~CharacterName = ""
~Music = 4
С потолка падает капля воды. Кап... кап...

~TurtleEmotion = 10

Внезапно, Шен выскакивает из тени, его кинжал блестит, будто только из ножен Адской кухни.
Одно мгновение, и пространство взрывается движением.
~KunitsaEmotion = 9
~CharacterName = "Лекс"
Сза—!
~KunitsaEmotion = 8
~CharacterName = ""
~Music = 3
Лезвие рассекает воздух, как кипяток паутину. Лекс срывается с ног, падает навзничь, глаза закатываются.

~KunitsaEmotion = 11
~TurtleEmotion = 0
~Music = 8
Рикки яростно, с глухим рыком, бросается вперёд, выхватывая нож.
~CharacterName = "Рикки"
Ты, зелёная тварь!
~CharacterName = ""
~TurtleEmotion = 5
Но справа, как змея из норы, появляется Рекс.
~TurtleEmotion = 6
~KunitsaEmotion = 0
Его кулак летит смертельной дугой, пробивая бок Рикки. Тело Рикки обмякло.
~TurtleEmotion = 0
~KunitsaEmotion = 20
~CharacterName = "Дейв"
Нас слишком мало...
~TurtleEmotion = 0
~CharacterName = ""
Вдруг, сзади послышался шорох. Дейв бросил взгляд за спину.
~KunitsaEmotion = 18
~CharacterName = "Дейв"
Главный, беги!!!
~CharacterName = ""
~TurtleEmotion = 19
~KunitsaEmotion = 22
Появившийся неожиданно Билли ударяет Дейва своим лассо. Тот с хрустом падает на землю.
Вокруг разбросаны тела куниц, лежащие без движения. Ужас парализовал Главного.
~Music = 2
Сердце забилось так сильно, словно сейчас проломит грудную клетку.
~TurtleEmotion = 0
~KunitsaEmotion = 2
В живых остался только Главный. Брок и Рекс не спеша идут к нему.
~KunitsaEmotion = 1
Главный достаёт пистолет.
    +[Убить Брок]
        ->BrokKilled
    +[Убить Рафаэля]
        ->ReksKilled
->END

=== BrokKilled ===
~Music = 1
Пуля со свистом вылетает из дула пистолета и попадает в голову Брока. 
Его взгляд затуманился, тело пошатнулось и с гулким звуком распласталось по холодному бетонному полу. 
->EndOfFight

=== ReksKilled ===
~Music = 1
Громкий выстрел оглушил всех в комнате. Когда дым рассеялся, все увидели Рафа — его тело лежало на покрытом кровью полу. 
Пуля пробила грудь, задев сердце. 
->EndOfFight

=== EndOfFight ===
~KunitsaEmotion = 1
~Music = -1
~CharacterName = "Главный"
Мне удалось выиграть немного времени, нужно убираться отсюда, пока его товарищи не вспомнили про меня!
~CharacterName = ""
Главный направился в глубь туннеля.
->END