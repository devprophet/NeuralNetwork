/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   NeuralNetwork.cs                                   :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: Alexis G. <alex.code@icloud.com>           +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/30 01:12:47 by Alexis G.         #+#    #+#             */
/*   Updated: 2018/04/30 14:30:23 by Alexis G.        ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */

using System;

namespace NeuralNetwork
{
    public class NeuralNetwork {
        /* Décris la composition du réseau de neurones */
        public int[] Layers { get; private set; }

        /* Les neurones du réseau de neurones */
        public float[][] Neurons { get; private set; }
        
        /* Les poids des  axons qui relie chaque neurones entre eux */
        public float[][][] Weight { get; private set; }

        /* Crée un réseau de neurone */
        public NeuralNetwork (int[] Layers, bool useRandom = true) {
            this.Layers = Layers;
            InitializeNeuralNetwork (useRandom);
        }

        /* Crée un réseau de neurones a partir d'une ADN */
        public NeuralNetwork (Genetics.DNA dna, bool useRandom = true) {
            this.Layers = dna.neuralNetworkStructure;
            InitializeNeuralNetwork (useRandom);
        }

        /* Initialise le réseau de neurones. */
        private void InitializeNeuralNetwork (bool useRandom = true) {
            
            Neurons = new float[Layers.Length][];
            Weight  = new float[Layers.Length][][];

            for ( int layer = 0; layer < Layers.Length; layer ++ ) {

                Neurons[layer]  = new float[Layers[layer]];
                Weight [layer]  = new float[Layers[layer]][];

                for ( int neuron = 0; neuron < Layers[layer]; neuron ++ ) {
                    /* Ici on attribut la valeur des neurones, par defaut 0 */
                    Neurons[layer][neuron]  = 0f;
                    Weight [layer][neuron]  = new float[layer + 1 < Layers.Length ? Layers[layer + 1] : 0];

                    for ( int axon = 0; axon < Weight[layer][neuron].Length; axon ++ ) {
                        /* Ici on attribut les poids de toutes les axones */
                        Weight[layer][neuron][axon] = useRandom ? Genetics.Rand.GetRand() : 0.5f;
                    }

                }

            }

        }

        /* 
            Propage les données en parametre dans le reseau de neurones 
            /!\ la taille du tableau en parametre doit correspondre aux nombres de neurones dans la couche d'entrée du reseau de neurones
        */
        public float[] Propagate (float[] Inputs) {

            /* Met les inputs dans les neurones d'entrée */
            for ( int i = 0; i < Neurons[0].Length; i ++ )
                Neurons[0][i] = Inputs[i];

            /* Propage les données en d'entrée dans le réseau de neurones */
            for (int layer = 1; layer < Layers.Length; layer ++ ) {
                for (int neuron = 0; neuron < Layers[layer]; neuron ++ ) {
                    
                    /* Met la valeur du neurone a 0 */
                    Neurons[layer][neuron] = 0f;

                    /* Fait la somme des axones * neurones */
                    for (int _neuron = 0; _neuron < Layers[layer - 1]; _neuron ++ )
                        Neurons[layer][neuron] += Neurons[layer - 1][_neuron] * Weight[layer - 1][_neuron][neuron];
                    
                    /* Applique la fonction sigmoid sur la somme des axons * neurones */
                    Neurons[layer][neuron] = sigmoid(Neurons[layer][neuron]);
                    
                }
            }

            /* Le tableau contenant les valeurs des derniers neurones (neurones de sortie) */
            float[] outputs = new float[Layers[Layers.Length - 1]];

            /* Assigne la valeur des neurones de sortie dans le tableau des outputs */
            for (int i = 0; i < outputs.Length; i ++ )
                outputs[i] = Neurons[Layers.Length - 1][i];

            /* retourne le tableau des outputs */
            return outputs;
            
        }

        /* La fonction sigmoid, la valeur retourner et comprise entre 0.0 et 1.0 */
        public float sigmoid (float x) {
            return 1f / (1f + MathF.Exp(-x));
        }

    }
}