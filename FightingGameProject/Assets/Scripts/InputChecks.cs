using UnityEngine;
using System.Collections;

public class InputChecks {

	public static bool ForwardDashed(bool[,] buffer, int forward) {
		int fInputCount = 0, lastForward = 0;
		for(int i = InputBuffer.bufferSize - 1; i >= 1; i--) {
			if(lastForward > i) {
				for(int j = 0; j < Inputs.NUMINPUTS; j++) {
					if(j != forward && buffer[i,j]) {
						lastForward = 0;
						fInputCount = 0;
					}
				}
			}
			
			if(!buffer[i,forward] && buffer[i-1,forward]) {
				fInputCount++;
				lastForward = i;
			}
			
			if(fInputCount > 1)
				return true;
		}
		
		return false;
	}
	
	public static bool BackDashed(bool[,] buffer, int backward) {
		int bInputCount = 0, lastBackward = 0;
		for(int i = InputBuffer.bufferSize - 1; i >= 1; i--) {
			if(lastBackward > i) {
				for(int j = 0; j < Inputs.NUMINPUTS; j++) {
					if(j != backward && buffer[i,j]) {
						lastBackward = 0;
						bInputCount = 0;
					}
				}
			}
			
			if(!buffer[i,backward] && buffer[i-1,backward]) {
				bInputCount++;
				lastBackward = i;
			}
			
			if(bInputCount > 1)
				return true;
		}
		
		return false;
	}
	
	public static bool QCF(bool[,] buffer, int down, int df, int f) {
		bool downb = false,dfb = false,fb = false;
		for(int i = InputBuffer.bufferSize - 1; i >= 0; i--) {
			if(buffer[i,down])
				downb = true;
			
			if(buffer[i,df] && downb)
				dfb = true;
			
			if(buffer[i,f] && dfb)
				fb = true;
			
			if(downb && dfb && fb)
				return true;
		}
		
		return false;
	}
	
	public static bool QCB(bool[,] buffer, int down, int db, int b) {
		//direction(boolean)
		bool downb = false,dbb = false,bb = false;
		for(int i = InputBuffer.bufferSize - 1; i >= 0; i--) {
			if(buffer[i,down])
				downb = true;
			
			if(buffer[i,db] && downb)
				dbb = true;
			
			if(buffer[i,b] && dbb)
				bb = true;
			
			if(downb && dbb && bb)
				return true;
		}
		
		return false;
	}
	
	public static bool DP(bool[,] buffer, int down, int df, int f) {
		bool downb = false,dfb = false,fb = false;
		for(int i = InputBuffer.bufferSize - 1; i >= 0; i--) {
			if(buffer[i,f])
				fb = true;
			
			if(buffer[i,down] && fb)
				downb = true;
			
			if(buffer[i,df] && downb)
				dfb = true;
			
			if(dfb && downb && fb)
				return true;
		}
		
		return false;
	}
	
	public static bool QCFP(bool[,] buffer, int down, int df, int f, int punch) {
		if(QCF(buffer,down,df,f) && buffer[0,punch]) {
			return true;
		}
		
		return false;
	}
	
	public static bool DPP(bool[,] buffer, int down, int df, int f, int punch) {
		if(DP(buffer,down,df,f) && buffer[0,punch]) {
			return true;
		}
		
		return false;
	}
}
