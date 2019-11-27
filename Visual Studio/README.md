1) Neues Projekt vom Typ Azure Function anlegen
1) Neue Funktion Store-Event mit Http Trigger anlegen
1) Neues Parameter vom Typ `IAsyncColletor<EventStoreData>` anlegen
1) Den Parameter mit dem Attribut `EventStoreStreams` markieren
1) Verarbeiten des parameters (Code siehe Repo)
1) Fertig

Naja fast. Zum Lesen der gespeicherten Events brauchen wir eine weitere Http Triggeres Funktion, die noch hinzugefügt werden muss. (Code siehe Repo)