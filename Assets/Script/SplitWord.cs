using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitWord : MonoBehaviour
{
    private static string mStartTbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
    private static string mMiddleTbl = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
    private static string mEndTbl = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
    private static ushort mUniCodeKorBase = 0xAC00;
    private static ushort mUniCodeKorLast = 0xD79F;
    private static string mStart;
    private static string mMiddle;
    private static string mEnd;
    
    public string SplitString(string str)
    {
        char cWork;
        cWork = char.Parse(str);

        SplitChar(cWork);
        return mStart + mMiddle + mEnd;
    }

    public void SplitChar(char InputChar)
    {
        try
        {
            int iStartIdx, iMiddleIdx, iEndIdx; // 초성,중성,종성의 인덱스
            ushort uTempCode = 0x0000;       // 임시 코드용
                                             //Char을 16비트 부호없는 정수형 형태로 변환 - Unicode
            uTempCode = Convert.ToUInt16(InputChar);
            // 캐릭터가 한글이 아닐 경우 처리
            if ((uTempCode < mUniCodeKorBase) || (uTempCode > mUniCodeKorLast))
            {
                mStart = ""; mMiddle = ""; mEnd = "";
            }
            // iUniCode에 한글코드에 대한 유니코드 위치를 담고 이를 이용해 인덱스 계산.
            int iUniCode = uTempCode - mUniCodeKorBase;
            iStartIdx = iUniCode / (21 * 28);
            iUniCode = iUniCode % (21 * 28);
            iMiddleIdx = iUniCode / 28;
            iUniCode = iUniCode % 28;
            iEndIdx = iUniCode;
            mStart = new string(mStartTbl[iStartIdx], 1);
            mMiddle = new string(mMiddleTbl[iMiddleIdx], 1);
            mEnd = new string(mEndTbl[iEndIdx], 1);
        }
        catch
        { }
    }
}
