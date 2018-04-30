/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   DNA.cs                                             :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: Alexis G. <alex.code@icloud.com>           +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/30 01:15:06 by Alexis G.         #+#    #+#             */
/*   Updated: 2018/04/30 01:15:08 by Alexis G.        ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */

using System;
using System.Collections.Generic;

namespace Genetics {

    [System.Serializable]
    public struct DNA {
        
        /* La structure du réseau de neurones */
        public int[] neuralNetworkStructure;

        /* Les genes */
        public float[] genes { get; set; }

        /* Crée une nouvelle ADN avec une taille précise des genes */
        public DNA (int genesLength, int[] neuralNetworkStructure) {
            this.neuralNetworkStructure = neuralNetworkStructure;
            genes = new float[genesLength];
        }

        /* Crée une nouvelle ADN ou les genes peuvent contenir les poids des axones du réseau de neurones */
        public DNA (NeuralNetwork.NeuralNetwork neuralNetwork) {
            genes = new float[0];
            neuralNetworkStructure = neuralNetwork.Layers;
            Initialize(neuralNetwork);
        }

        /* Initialise l'adn avec des valeurs aléatoires */
        public void Initialize () {
            
            if (genes == null)
               throw new Exception ( "Les genes ne sont pas initialiser!" );

            var random = new Random();
            for (int i = 0; i < genes.Length; i++ )
                genes[i] = (float)random.NextDouble();

        }

        /* Initialise l'adn à partire d'un réseau de neurones */
        public void Initialize (NeuralNetwork.NeuralNetwork with) {
            List <float> _genes = new List <float> ();
            for (int layer = 0; layer < with.Weight.Length; layer ++ )
                for (int neuron = 0; neuron < with.Weight[layer].Length; neuron ++ )
                    for (int axon = 0; axon < with.Weight[layer][neuron].Length; axon ++ )
                        _genes.Add(with.Weight[layer][neuron][axon]);
            this.genes = _genes.ToArray();
        }
        
        /* Permet de muter des gènes */
        public void Mutate (int chanceOfMutation) {
            for ( int i = 0; i < genes.Length; i ++ ) {
                /* chanceOfMutation chance sur 100 que un gene mute */
                if (Genetics.Rand.GetRandInt(0, 100) < chanceOfMutation) {
                    /* Mute le gene */
                    genes[i] = Genetics.Rand.GetRand();
                }
            }
        }

        /* Mélange uniformement les caractéristiques de l'adn actuelle avec celle d'un autre */
        public DNA CrossOver (DNA with) {
            
            if (with.genes.Length != genes.Length)
                throw new Exception("Le crossover ne peut pas s'effectuer correctement car les genes ne sont pas de la meme taille!");
            
            DNA child = new DNA(genes.Length, neuralNetworkStructure);

            for ( int i = 0; i < child.genes.Length; i ++ )
                child.genes[i] = (Genetics.Rand.GetRandInt(0, 2) == 0) ? genes[i] : with.genes[i];

            return child;
        }

    }

}