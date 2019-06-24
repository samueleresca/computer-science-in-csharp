using System;
using System.Collections.Generic;
using System.Linq;

namespace HandsOn.Algorithms.ArraysAndStrings
{
    public class ShortestSubArrayWithSum
    {
        
    
        public int shortestSubarray(int[] A, int K) {
            var size = A.Length;
            int[] P = new int[size+1];
            
            for (int i = 0; i < size; ++i)
                P[i+1] = P[i] + A[i];

            // Want smallest y-x with P[y] - P[x] >= K
            int ans = size+1;
            Queue<int> monoq = new Queue<int>(); //opt(y) candidates, as indices of P

            for (int y = 0; y < P.Length; ++y) {
                // Want opt(y) = largest x with P[x] <= P[y] - K;
                while (monoq.Count > 0 && P[y] <= P[monoq.Last()])
                    monoq.Dequeue();
                while (monoq.Count > 0 && P[y] >= P[monoq.First()] + K)
                    ans = Math.Min(ans, y - monoq.First());

                monoq.Enqueue(y);
            }

            return ans < size+1 ? ans : -1;
        }
    }
}