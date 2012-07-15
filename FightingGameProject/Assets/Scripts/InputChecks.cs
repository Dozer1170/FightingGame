using UnityEngine;
using System.Collections;

public class InputChecks {

	public static bool ForwardDashed(bool[,] buffer, int forward) {
		int fInputCount = 0;
		for(int i = 0; i < InputBuffer.bufferSize - 1; i++) {
			if(buffer[i,forward] && !buffer[i+1,forward])
				fInputCount++;
			
			if(fInputCount > 1)
				return true;
		}
		
		return false;
	}
	
	public static bool BackDashed(bool[,] buffer, int backward) {
		int bInputCount = 0;
		for(int i = 0; i < InputBuffer.bufferSize - 1; i++) {
			if(buffer[i,backward] && !buffer[i+1,backward])
				bInputCount++;
			
			if(bInputCount > 1)
				return true;
		}
		
		return false;
	}
	
	public static bool QCF(int currBufferFrame, bool[,] buffer) {
		return false;
	}
	
	public static bool QCB(int currBufferFrame, bool[,] buffer) {
		return false;
	}
}
