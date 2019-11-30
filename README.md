## MoeCalculator

Small CLI app, that helps to build the most effective item set in "Moe! Ninja Girls" game.
Set your items in Data\items.json and run program.

### Arguments & help screen
```shell
MoeCalculator 1.0.0
Copyright (C) 2019 MoeCalculator

  -d, --difference      Sets preffered average difference between element totals.

  -m, --min-total       Sets minimal summary total value of the result set.

  --include-ninjutsu    Specifies whether should ninjutsu be included in calculation or not.

  --help                Display this help screen.

  --version             Display version information.
```

### Run example
```shell
D:\Moe\MoeCalculator\bin\Debug\netcoreapp3.0>MoeCalculator -d 100 --include-ninjutsu

Items:
        Ice     131     Image   Ricka
        Flame   15      Scroll  Red for Ninjas
        Thunder 20      Arm     Tengge's Full-Moon Fan
        Thunder 55      Throw   Snow Maiden Fan
        Ninju   35      Skill   Ninjutsu Skill
        Flame   40      Gem     Clue Crystal Charm
        Flame   25      Charm   Horsie Wooden Plaque
        Flame   32      Amulet  Poodle Stuffed Animal
        Thunder 11      Bomb    White Papier-mache Grenade
        Thunder 0       Extra   Empty Item
        Thunder 10      Food    Black Nonperishables
        Ninju   10      Backgr  Ricka's Birthday Background

Total value: 384

        Flame total: 112
        Ice total: 131
        Thunder total: 96
        Ninjutsu total: 45
```
