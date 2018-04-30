/* ************************************************************************** */
/*                                                                            */
/*                                                        :::      ::::::::   */
/*   Rand.cs                                            :+:      :+:    :+:   */
/*                                                    +:+ +:+         +:+     */
/*   By: Alexis G. <alex.code@icloud.com>           +#+  +:+       +#+        */
/*                                                +#+#+#+#+#+   +#+           */
/*   Created: 2018/04/30 01:14:58 by Alexis G.         #+#    #+#             */
/*   Updated: 2018/04/30 14:31:23 by Alexis G.        ###   ########.fr       */
/*                                                                            */
/* ************************************************************************** */

using System;

namespace Genetics {

    public static class Rand {

        private static Random random;

        private static bool initialized = false;
        
        public static float GetRand() {
            if (!initialized)
                random = new Random();
            return (float)random.NextDouble();
        }

        public static int GetRandInt() {
            if (!initialized)
                random = new Random();
            return random.Next();
        }

        public static int GetRandInt(int min, int max) {
            if (!initialized)
                random = new Random();
            return random.Next(min, max);
        }
    }

}