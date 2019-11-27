# Baue dir deinen Serverless EventStore

Grundsätzlich ist es sehr einfach den [EventStore](https://eventstore.org/) serverless zu machen. Manche mögen sich sogar fragen, warum man das machen sollte/möchte. Die Antwort ist recht einfach. Zum einen, weil es geht und zum anderen ist es gerade in verteilten Applikationen ziemlich praktisch, wenn man keinen bunten Blumenstrauß an SDKs/Libs oder Frameworks benutzt. 
In der letzten Zeit haben sich die REST Services auch als JSON RPCs etabliert. Sie sind einfach umzusetzen und gelten als eine Art Quasistandard. Darum ist es erstrebenswert möglichst viel Kommunikation darüber zu erledigen. Das führt uns dahin, dass man den EventStore auch per Http Client anspricht.

Wie man das mit Technologien der Azure Cloud macht, soll mit diesem Repository beschrieben werden

## Umgebung
Es gibt mehrere Wege sich der Umsetzung zu nähern.

1.) Mit dem Visual Studio 2017 oder 2019 und den Azure Cloud Erweiterungen
Damit ist alles soweit installiert, was man braucht. Ich empfehle dazu natürlich auch dotnet Core in der aktuellen Version 2.2 (Stand Nov. 2019). Es ist durchaus auch möglich mit dotnet Core 3.x zu entwickeln.

2.) Mit einem anderen Editor z.B. Visual Studio Code
Wer mit Code entwickeln möchte braucht auch NodeJs > 10.x und das npm package azure-functions-core-tools. Code selbst sollte noch die Azure Functions Extension bekommen, dann lassen sich Function Apps auch in die Cloud heben.

3.) Mit JetBrains Rider
Hier ist es ähnlich wie mit Visual Studio. Azure Erweitung installieren und man hat alles, was man braucht.


## Tutorial

Im Repo gibt es für jede angesprochene IDE einen Ordner in der jeweils eine weitere, ergänzende README liegt. Zu dem liegt hier im Hauptverzeichnis eine [PDF](FürDenWorkshop.pdf), die die Powerpoint Präsentation enthält, die im DDC 2019 Workshop verwendet wurde. Sie enthält ebenfalls eine Beschreibung, wie man einen Serverless EventStore einrichtet.

WICHTIG, dieses Repo geht davon aus:
* dass eine EventStore Instanz in einem lokalen docker Container installiert ist
* dass die local.settings.json korrekt konfiguriert ist
    * AzureWebJobsStorage ist lokal mit hilfe des Emulators eingerichtet (siehe PDF)
    * EventStoreConnection zeigt auf localhost Port 1113