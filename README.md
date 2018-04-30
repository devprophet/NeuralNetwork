# Neural Network & Genetic
API Permettant de crée et utilisé un réseau de neurones (sans back propagation), ainsi que le combiné avec l'algorithme génétique.

## Exemple
### Crée un réseau de neurones
Exemple pour crée un réseau de neurones comportant 3 couches (*layers*) :
1. La couche d'entrée et composer de **4 neurones** (*soit 4 inputs*).
2. La couche caché et composer de **4 neurones**.
3. La couche de sortie et composer de **2 neurones** (*soit 2 outputs*).
``` Csharp

    using NeuralNetwork; 

    // Crée notre réseau de neurones .
    var neuralNetwork = new NeuralNetwork( new int[] { 4, 4, 2 } );

    // Propage les donées dans le réseau de neurones .
    var outputs = neuralNetwork.Propagate( new float[] { 0, 1, 0, 1} );

    // Affiche les résultats de sorties .
    foreach ( var output in outputs )
        Console.WriteLine ( output );
```
dwd