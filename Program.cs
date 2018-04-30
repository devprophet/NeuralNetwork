/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   Program.cs                                         :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: Alexis G. <alex.code@icloud.com>           +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/30 01:15:13 by Alexis G.         #+#    #+#             */
/*   Updated: 2018/04/30 01:15:13 by Alexis G.        ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */

using System;
using NeuralNetwork;
using Genetics;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var neural1  = new NeuralNetwork ( new int[] {4, 4, 2} );
            var neural2  = new NeuralNetwork ( new int[] {4, 4, 2} );

            Console.WriteLine( "Valeurs d'entrées : 0 1 0 1" );

            Console.WriteLine ( "-- --- --- --- --- --- --- --" );

            /* Test de la propagation des données, on doit obtenir les mêmes résultats si on mets les mêmes entrées! */
            Console.WriteLine( "Reseau neuronal 1" );
            for ( int i = 0; i < 2; i ++ ) {
                var results = neural1.Propagate (new float[]{ 0, 1, 0, 1 });
                Console.Write(string.Format("n{0}\n", i));
                foreach (var result in results)
                    Console.WriteLine(result.ToString());
                Console.Write("\n");
            }

            Console.WriteLine ( "-- --- --- --- --- --- --- --" );

            Console.WriteLine( "Reseau neuronal 2" );
            for ( int i = 0; i < 2; i ++ ) {
                var results = neural2.Propagate (new float[]{ 0, 1, 0, 1 });
                Console.Write(string.Format("n{0} : \n", i));
                foreach (var result in results)
                    Console.WriteLine(result.ToString());
                Console.Write("\n");
            }

            Console.WriteLine ( "-- --- --- --- --- --- --- --" );

            Console.WriteLine( "CrossOver" );
            /* Test du cross-over */
            DNA parent1 = new DNA(neural1);
            DNA parent2 = new DNA(neural2);

            DNA child1 = parent1.CrossOver(parent2);
            DNA child2 = parent2.CrossOver(parent1);

            Console.WriteLine ( "\nSans mutation\n" );
            for ( int i = 0; i < parent1.genes.Length; i ++ ) {
                Console.Write ( string.Format( "P1 : {0} | P2 : {1} | C1 : {2}{4} | C2 : {3}{5}\n", 
                        Math.Round(parent1.genes[i], 5), 
                        Math.Round(parent2.genes[i], 5), 
                        Math.Round(child1.genes[i], 5), 
                        Math.Round(child2.genes[i], 5),
                        child1.genes[i] == parent1.genes[i] ? " (P1)" : child1.genes[i] == parent2.genes[i] ? " (P2)" : " (MU)",
                        child2.genes[i] == parent1.genes[i] ? " (P1)" : child2.genes[i] == parent2.genes[i] ? " (P2)" : " (MU)"
                    )
                );
            }

            int mutationRate = 5;
            child1.Mutate(mutationRate);
            child2.Mutate(mutationRate);
            Console.WriteLine ( string.Format("\nAvec un taux de mutation a {0}/100 par gènes, soit une déterioration de l'ADN de {1}% max, ce qui fait que l'ADN contient au min {2}% des gènes des parents.\n", mutationRate, (mutationRate / 100.0) * 100, 100.0 - (mutationRate)));
            for ( int i = 0; i < parent1.genes.Length; i ++ ) {
                Console.Write ( string.Format( "P1 : {0} | P2 : {1} | C1 : {2}{4} | C2 : {3}{5}\n", 
                        Math.Round(parent1.genes[i], 5), 
                        Math.Round(parent2.genes[i], 5), 
                        Math.Round(child1.genes[i], 5), 
                        Math.Round(child2.genes[i], 5),
                        child1.genes[i] == parent1.genes[i] ? " (P1)" : child1.genes[i] == parent2.genes[i] ? " (P2)" : " (MU)",
                        child2.genes[i] == parent1.genes[i] ? " (P1)" : child2.genes[i] == parent2.genes[i] ? " (P2)" : " (MU)"
                    )
                );
            }

            var childNeural1 = new NeuralNetwork(child1);
            var childNeural2 = new NeuralNetwork(child2);

            var child1Result = childNeural1.Propagate(new float[]{0, 1, 0, 1});
            var child2Result = childNeural2.Propagate(new float[]{0, 1, 0, 1});

            Console.WriteLine("Resultat du child 1 : ");
            foreach (var result in child1Result) {
                Console.Write ( result.ToString() + "\n" );
            }

            Console.WriteLine("\nResultat du child 2 : ");
            foreach (var result in child2Result) {
                Console.Write ( result.ToString() + "\n" );
            }

        }
    }
}
