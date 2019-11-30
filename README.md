## MoeCalculator

Little CLI app, that helps to build the most effective item set in "Moe! Ninja Girls: game.
Set your items in Data\items.json and run program.

### Arguments & help screen
```shell
MoeCalculator 1.0.0
Copyright (C) 2019 MoeCalculator

  -d, --difference    Sets preffered average difference between element totals.

  -m, --min-total     Sets minimal summary total value of the result set.

  --help              Display this help screen.

  --version           Display version information.
```

### Run example
```shell
D:\Moe\MoeCalculator\bin\Debug\netcoreapp3.0>moecalculator -d 10 -m 350

Items:
        Flame   122     Image   Akari
        Thunder 13      Scroll  Light Blue Fat with Gold Cord
        Thunder 20      Arm     Tengge's Full-Moon Fan
        Thunder 55      Throw   Snow Maiden Fan
        Thunder 35      Skill   Enju's Enhanced Lightning Jutsu
        Ice     16      Gem     Black Prayer Beads
        Ice     42      Charm   Pink Crystal Talisman
        Ice     10      Amulet  Plain Wood for Decoy
        Ice     27      Bomb    Purple Giant
        Thunder 0       Extra   Empty Item
        Ice     32      Food    Ricka's Birthday Cake

Total value: 372

        Flame total: 122
        Ice total: 127
        Thunder total: 123
```
