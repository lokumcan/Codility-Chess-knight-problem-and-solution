//------------------------------------------------------------------------------
// Written by Shbli
//
// Contact and details: shbli.com
//
//------------------------------------------------------------------------------


// The knight is a piece in the game of chess that in one turn can move two
// squares horizontally and one square vertically or two squares vertically
// and one square horizontally.

// An infinite chessboard is given. All of its squares are empty except for
// the square with coordinates (0, 0) where a knight stands.

// Write a function
//   def min_count_of_knight_moves(A,B)
// that given two numbers A and B returns the minimal number of turns required
// for the knight to move from square (0, 0) to square (A, B). The function
// should return -1 if the knight cannot reach given square. The function
// should return −2 if the required number of turns exceeds 100,000,000.

// Assume that:
//   A is an integer within the range [-100,000,000..100,000,000];
//   B is an integer within the range [-100,000,000..100,000,000].

// For example, given A = 4 and B = 5 the function should return 3 because the
// knight requires 3 turns to move from square (0, 0) to square (4, 5): in the
// first turn the knight moves from square (0, 0) to square (2, 1), in the
// second turn the knight moves from square (2, 1) to square (3, 3), in the
// third turn the knight moves from square (3, 3) to square (4, 5).

// Complexity:
//   expected worst-case time complexity is O(1);
//   expected worst-case space complexity is O(1).

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Solution {

	int moveTowardsPoint(int currentPoint, int moveToPoint, int pSteps) {
		//ex, current point is 5 and move point is 8
		if (currentPoint < moveToPoint) {
			//ex steps are 2, return 7
			return (currentPoint+pSteps);
		}
		// *** else ***
		//ex, current point is 8 and move point is 5
		//ex steps are 2, return 6
		return (currentPoint-pSteps);
		
	}
	
	public int solution(int A, int B) {
		// write your code in C# 6.0 with .NET 4.5 (Mono)
		int requiredSteps = -1;
		int APos = 0;
		int BPos = 0;
		//handle the 0,0 case
		if (APos == A && BPos == B) {
			return 0;
		}
		int maxSteps = 250;
		//temp for testing purposes
		//		maxSteps = 100;
		
		//move the knight closer to A and B
		while (requiredSteps <= maxSteps+1) {
			requiredSteps++;
			Console.WriteLine("Step " + requiredSteps + " ( " + APos + " , " + BPos + " )");

			//move 2 steps towards A and one towards B
			if (Math.Abs( APos - A ) == 2 && Math.Abs( BPos - B ) == 1) {
				APos = moveTowardsPoint(APos,A,2);
				BPos = moveTowardsPoint(BPos,B,1);
				continue;
			}
			
			//move 2 steps towards A and one towards B
			if (Math.Abs( APos - A ) == 1 && Math.Abs( BPos - B ) == 2) {
				APos = moveTowardsPoint(APos,A,1);
				BPos = moveTowardsPoint(BPos,B,2);
				continue;
			}
			
			//piortize A
			if (Math.Abs( APos - A ) > Math.Abs( BPos - B )) {
				//move 2 steps towards A and one towards B
				if (Math.Abs( APos - A ) >= 2 && Math.Abs( BPos - B ) >= 1) {
					APos = moveTowardsPoint(APos,A,2);
					BPos = moveTowardsPoint(BPos,B,1);
					continue;
				}
				
				//move 2 steps towards B and one towards A
				if (Math.Abs( APos - A ) >= 1 && Math.Abs( BPos - B ) >= 2) {
					APos = moveTowardsPoint(APos,A,1);
					BPos = moveTowardsPoint(BPos,B,2);
					continue;
				}
			} else {
				//piortize B
				//move 2 steps towards B and one towards A
				if (Math.Abs( APos - A ) >= 1 && Math.Abs( BPos - B ) >= 2) {
					APos = moveTowardsPoint(APos,A,1);
					BPos = moveTowardsPoint(BPos,B,2);
					continue;
				}
				
				//move 2 steps towards A and one towards B
				if (Math.Abs( APos - A ) >= 2 && Math.Abs( BPos - B ) >= 1) {
					APos = moveTowardsPoint(APos,A,2);
					BPos = moveTowardsPoint(BPos,B,1);
					continue;
				}
			}

			//if we are one step by B and A
			if (Math.Abs( APos - A ) == 1 && Math.Abs( BPos - B ) == 1) {
				//further a step from A, and closer 2 steps to B
				APos = moveTowardsPoint(APos,A,-1);
				BPos = moveTowardsPoint(BPos,B,2);
				continue;
			}

			if (Math.Abs( APos - A ) == 1 && Math.Abs( BPos - B ) == 0) {
				//further a step from A, and closer 2 steps to B
				APos = moveTowardsPoint(APos,A,2);
				BPos = moveTowardsPoint(BPos,B,1);
				continue;
			}

			if (Math.Abs( APos - A ) == 0 && Math.Abs( BPos - B ) == 1) {
				//further a step from A, and closer 2 steps to B
				APos = moveTowardsPoint(APos,A,1);
				BPos = moveTowardsPoint(BPos,B,2);
				continue;
			}

			
			if (APos == A && BPos == B) {
				return requiredSteps;
			}
		}
		
		//steps are way off
		if (requiredSteps >= maxSteps) {
			return -2;
		}
		
		return requiredSteps;
	}

	static void Main(string[] args) {
		Console.WriteLine("Started");
		Console.WriteLine("***");

		Solution s = new Solution();
		int A = 97;
		int B = 78;
		Console.WriteLine( "Sol is " + s.solution(A,B) );

		Console.WriteLine("***");
		Console.WriteLine("End");
	}
}