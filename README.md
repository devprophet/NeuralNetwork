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
(#t-0) 
### Crée une ADN a partir d'un réseau de neurones
Exemple montrant la création d'une ADN a partir d'un réseau de neurones :
```csharp
    using NeuralNetwork;
    using Genetics;

    // Crée mon réseau de neurones
    var neuralNetwork = new NeuralNetwork( new int[] { 4, 4, 2 });

    // Crée une adn à partir d'un réseau de neurones
    var dna = new DNA ( neuralNetwork );
```

### Crée une ADN à partir de deux autres ADN ( CrossOver )
Exemple montrant la création d'une nouvelle ADN à partir de deux autres ADN. La nouvelle ADN comporteras un mélanges uniform des gènes des deux parents.
```csharp
using NeuralNetwork;
using Genetics;

// Crée le réseau neuronal du parent A.
var neuralNetworkA = new NeuralNetwork( new int[] { 4, 4, 2 } );
// Crée le réseau neuronal du parent B.
var neuralNetworkB = new NeuralNetwork( new int[] { 4, 4, 2 } );

// Crée l'ADN du parent A a partir de son réseau de neurones.
var dna_a = new DNA ( neuralNetworkA );
// Crée l'ADN du parent B a partir de son réseau de neurones.
var dna_b = new DNA ( neuralNetworkB );
// Crée une nouvelle ADN a partir de deux ADN (dna_a et dna_b)
var dna_c = dna_a.CrossOver ( dna_b );
```

### Muter une ADN ( Mutation )
Exemple montrant la mutation des gènes d'une ADN. La mutation se base sur un taux de mutations par gènes. C'est x chance(s) sur 100 que un gène mute. Ou x et le taux de mutations.
```csharp
using NeuralNetwork;
using Genetics;

// Crée le réseau neuronal du parent A.
var neuralNetwork = new NeuralNetwork( new int[] { 4, 4, 2 } );

// Crée l'ADN de son réseau de neurones.
var dna = new DNA ( neuralNetwork );

// Le tau de mutation par gène et de 5 chances sur 100
var mutateRate = 5;

// Mute le gène
dna.Mutate (mutateRate);

// Applique les valeurs du gène sur le réseau de neurones
neuralNetwork = new NeuralNetwork ( dna );
```

### Crée un réseau de neurones a partie d'une ADN
Exemple montrant la création d'un réseau de neurones a partie d'une ADN.
```csharp
using NeuralNetwork;
using Genetics;

// Crée le réseau neuronal du parent A.
var neuralNetwork = new NeuralNetwork( new int[] { 4, 4, 2 } );

// Crée l'ADN de son réseau de neurones.
var dna = new DNA ( neuralNetwork );

// Crée un nouveau réseau de neurones a partir de l'ADN d'un autre réseau de neurones.
var neuralNetworkB = new NeuralNetwork ( dna );
```