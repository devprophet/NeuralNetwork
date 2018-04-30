# Neural Network & Genetic
API Permettant de créer et utiliser un réseau de neurones (sans back propagation), ainsi que le combiné avec l'algorithme génétique.

- [Créer un réseau de neurones](#crée-un-réseau-de-neurones)
- [Créer un réseau de neurones à partir d'une ADN](#crée-un-réseau-de-neurones-a-partie-dune-adn)
- [Créer une ADN à partir d'un réseau de neurones](#crée-une-adn-a-partir-dun-réseau-de-neurones)
- [Créer une ADN à partir de deux autres ADN ( CrossOver )](#crée-une-adn-à-partir-de-deux-autres-adn--crossover-)
- [Effectuer une mutation sur une ADN ( Mutate )](#muter-une-adn--mutation-)

## Exemple
### Créer un réseau de neurones
Exemple pour créer un réseau de neurones comportant 3 couches (*layers*) :
1. La couche d'entrée est composée de **4 neurones** (*soit 4 inputs*).
2. La couche cachée est composée de **4 neurones**.
3. La couche de sortie est composée de **2 neurones** (*soit 2 outputs*).
``` Csharp
    using NeuralNetwork;

    // Créer notre réseau de neurones .
    var neuralNetwork = new NeuralNetwork( new int[] { 4, 4, 2 } );

    // Propage les donées dans le réseau de neurones .
    var outputs = neuralNetwork.Propagate( new float[] { 0, 1, 0, 1} );

    // Affiche les résultats de sorties .
    foreach ( var output in outputs )
        Console.WriteLine ( output );
```
### Créer une ADN à partir d'un réseau de neurones
Exemple montrant la création d'une ADN a partir d'un réseau de neurones :
```csharp
    using NeuralNetwork;
    using Genetics;

    // Créer mon réseau de neurones
    var neuralNetwork = new NeuralNetwork( new int[] { 4, 4, 2 });

    // Créer une adn à partir d'un réseau de neurones
    var dna = new DNA ( neuralNetwork );
```

### Créer une ADN à partir de deux autres ADN ( CrossOver )
Exemple montrant la création d'une nouvelle ADN à partir de deux autres ADN. La nouvelle ADN comportera un mélange uniform des gènes des deux parents.
```csharp
using NeuralNetwork;
using Genetics;

// Créer le réseau neuronal du parent A.
var neuralNetworkA = new NeuralNetwork( new int[] { 4, 4, 2 } );
// Créer le réseau neuronal du parent B.
var neuralNetworkB = new NeuralNetwork( new int[] { 4, 4, 2 } );

// Créer l'ADN du parent A à partir de son réseau de neurones.
var dna_a = new DNA ( neuralNetworkA );
// Créer l'ADN du parent B à partir de son réseau de neurones.
var dna_b = new DNA ( neuralNetworkB );
// Créer une nouvelle ADN à partir de deux ADN (dna_a et dna_b)
var dna_c = dna_a.CrossOver ( dna_b );
```

### Muter une ADN ( Mutation )
Exemple montrant la mutation des gènes d'une ADN. La mutation se base sur un taux de mutations par gènes. C'est x chance(s) sur 100 qu'un gène mute. Ou x et le taux de mutations.
```csharp
using NeuralNetwork;
using Genetics;

// Créer le réseau neuronal du parent A.
var neuralNetwork = new NeuralNetwork( new int[] { 4, 4, 2 } );

// Créer l'ADN de son réseau de neurones.
var dna = new DNA ( neuralNetwork );

// Le taux de mutation par gène et de 5 chances sur 100
var mutateRate = 5;

// Mute le gène
dna.Mutate (mutateRate);

// Applique les valeurs du gène sur le réseau de neurones
neuralNetwork = new NeuralNetwork ( dna );
```

### Créer un réseau de neurones à partir d'une ADN
Exemple montrant la création d'un réseau de neurones à partir d'une ADN.
```csharp
using NeuralNetwork;
using Genetics;

// Créer le réseau neuronal du parent A.
var neuralNetwork = new NeuralNetwork( new int[] { 4, 4, 2 } );

// Créer l'ADN de son réseau de neurones.
var dna = new DNA ( neuralNetwork );

// Créer un nouveau réseau de neurones à partir de l'ADN d'un autre réseau de neurones.
var neuralNetworkB = new NeuralNetwork ( dna );
```