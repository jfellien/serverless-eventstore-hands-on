Das notwendige Setup ist in der beigelegten PDF beschrieben. NodeJs und die azure functions core tools müssen installiert sein, sonst klappt es leider nicht.

1) In Code, im Terminal-Fenster, `func init` eingeben und anschließend `dotnet` auswählen
1) Mittels `func extensions install --package SiaConsulting.Azure.WebJobs.Extensions.EventStoreExtension.Streams --version 0.1.2` über das Terminal-Fenster das Binding installieren
1) Dann `func new` aufrufen, um eine Http triggered Function mit dem Namen StoreEvent zu erstellen
1) Der Code für die Funktion liegt im Repo
1) Das gleiche gilt für die Funtion ReadEvents