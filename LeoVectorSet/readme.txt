Készítsünk 3 dimenziós irányvektorok halmazát reprezentáló osztályt! A halmazban két ugyanolyan irányvektor nem szerepelhet.

Két vektort akkor tekintünk egyenlőnek, ha a két vektor által bezárt szög kisebb, mint valamely epszilon. Ez az epszilon a halmaz paramétere lesz (a konstruktorban kapja meg az osztály példánya).

A VectorSet.cs-ben megadtuk az osztály felületét, a feladat a hiányzó (NotImplementedException kivételt dobó) metódusok implementálása.

A feladatban előre megadott osztályokat/struktúrákat nyugodtan egészítsd ki a megvalósításhoz szükséges adattagokkal és függvényekkel. Ha szeretnéd, nyugodtan hozz létre további fájlokat és szervezd át a kódot.

A hatékonyság most nem szempont, a lényeg, hogy működjön jól.

Bónusz: nem kell implementálni, csak ötletelni. Milyen módszereket lehetne alkalmazni ahhoz, hogy az osztályban lévő Add, Remove és FindClosest műveletek a lehető leghatékonyabbak legyenek (minél kevesebb összehasonlítást kelljen végezni a halmazban lévő meglévő elemekkel)?