# DRUSTest

This is test repository, which will be used for DRUS subject.

STEP 1
In this step I added two console application and one class library. Two console applications represent two meteo stations, in solution MeteoStationGacko and
MeteoStationTrebinje. Class library in solution has name Common. In both meteo station I implemented logic for sending temperature and humidity data(temperature data every 1 sec and humidity data every 6 sec). In Common class library I keep common classes and interfaces which I use through the solution. In ScadaService console aplication I implemented server logic for accepting and displaying data sent from meteo stations.

STEP 2
In this step I added one console application which represent monitor client. Monitor client can subscribe and unsubscribe from certain sensor or sensors by entering sensors ids separated by comma. In Common class library I added two new interfaces "ISubsrcibeUnsubscribe", "INotifySubClinet" and one class "SubClientData" to support implementation of subscribe, unsubscribe and callback logic. Once monitor client subscribe for certain sensor or sensors, when new value come monitor client is notify by callback method "Notify" defined in "INotifySubClient" interface. In "ScadaServices" console application I added one more class "PubSubService" in which I implemented service for subscribe, unsubscribe operations used by monitor clients.