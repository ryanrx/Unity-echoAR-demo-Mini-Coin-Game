# Unity-echoAR-demo-Mini-Coin-Game
Simple Coin Game demo with Unity and echoAR.

## Setup
* [Add the 3D assets](https://docs.echoar.xyz/quickstart/add-a-3d-model) from the [assets](https://github.com/ryanrx/Unity-echoAR-demo-Mini-Coin-Game/tree/master/models) folder to the echoAR console.
* [Add the metadata](https://docs.echoar.xyz/web-console/manage-pages/data-page/how-to-add-data#adding-metadata) listed in the the [metadata](https://github.com/ryanrx/Unity-echoAR-demo-Mini-Coin-Game/tree/master/metadata) folder to the holograms.
* Open the [CoinGame](https://github.com/ryanrx/Unity-echoAR-demo-Mini-Coin-Game/tree/master/CoinGame) folder as a project in Unity.
* Fill in you API key in the echoAR game object.
* Open `CoinGame/Assets/Scripts/P1Controller.cs` and add your API key on line 10, `private string _apiKey = "<API_KEY>";`, and add your entry ID for the **Unicorn** model on line 12, `private string _entryID = "<ENTRY_ID>";`.
* Open `CoinGame/Assets/Scripts/P2Controller.cs` and add your API key on line 10, `private string _apiKey = "<API_KEY>";`, and add your entry ID for the **Eagle** model on line 12, `private string _entryID = "<ENTRY_ID>";`.

## Run
* Build and run the application.
* Player 1 uses WASD keys to control the Unicorn model, and Player 2 uses arrow keys to control the Eagle model.
* Try to get the coin.

## Screenshots
![Unity scene screenshot](/images/screenshot1.png)
![Unity scene screenshot](/images/screenshot2.png)
![echoAR console screenshot](/images/screenshot3.png)
![echoAR console screenshot](/images/screenshot4.png)