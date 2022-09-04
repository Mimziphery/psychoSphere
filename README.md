# psychoSphere
![game](https://user-images.githubusercontent.com/63194172/188317137-3afacc5d-3130-4f9d-9ec0-0fb5f842b2c9.PNG)

## Објаснување
Играта е проектна задача имплементирана на курсот Визуелно Програмирање.
Се работи за астронаут кој се наоѓа во атмосферата кој треба да одбегнува астероиди и да собира камења (дијаманти).
Целта на играта е да биде заразна, релаксирачка, но истовремено и еден тип на предизвик.
Се работи за сопствена идеја која се обидов да ја имплементирам.

## Начин на игра
Се користат копчињата со стрелки за движење лево/десно. Се користи space за скокање.
Секоја игра астронаутот има 3 животи кој може да ги губи ако падне долу или биде удрен од астероид. Тој треба да ги собира камењата и да скока низ платформите, одбегнувајќи ги астероидите.

## Имплементација
![This is an image](https://ucarecdn.com/76821ea4-0a36-4c6b-8736-38a1e827722f/)
> Дијаграмот го претставува начинот на функционира на играта (односно класата GameLoop чиј објект се креира при стартување на играта).
Се користат 3 класи и тоа GameLoop, Game и GameSprite.
GameLoop го содржи главниот циклус на играта, и при секој тик се повикува Update() методот на Game класата каде што се апдејтира движењето, графиката и логиката на играта. Преку GameSprite објекти се претставени сите цртачки објекти во играта (играчот, платформите, астероидите, дијамантите).
Во Game класата се чуваат GameSprite објекти за Player, посебни листи од GameSprite за астероиди, платформи, животи, дијаманти. Тие листи најчесто се генерираат рандом при промена на сцена (движење на играчот најдесно во сцената односно на крај, па враќање најлево односно на почеток) и при вчитување на игра.
При судир на играчот со астероид или дијамант, соодветно се отстранува тој објект од листата.


![kod](https://user-images.githubusercontent.com/63194172/188316906-36e01a0c-01cc-4172-a639-14eb788069e7.PNG)
> Кодот го претставува алгоритмот за генерирање на платформи по случаен избор. За секоја платформа од 10те што ќе се креираат и додадат на листата на платформи во циклусот, се генерираат случајни броеви за: еден број ко ќе ни помогне да одбереме која слика на платформата да ја избереме (тоа се одлучува при делење со остаток со 3, чиј остатоци се 3 можни случаеви кои одговараат со 3 можни слики за платформи), друг број кој ќе ја одреди висината помеѓу 200 и 550 (броевите се земени по мерење, да не биде многу долу и да не биде залепено горе), и уште еден број за растојание помеѓу платформите(помеѓу 100 и 200).
