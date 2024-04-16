using System.Numerics;

int numberOfSnowballs=int.Parse(Console.ReadLine());
int snowBallSnow = 0;
int snowBallTime = 0;
int snowBallQuality = 0;
BigInteger snowBallSnowAndTime = 0;
BigInteger snowBallFormula = 0;
BigInteger bestSnowBall = 0;
BigInteger bestSnowBallSnow = 0;
BigInteger bestSnowBallTime = 0;
BigInteger bestSnowBallQuality = 0;

for (int i = 1; i <= numberOfSnowballs; i++)
{
     snowBallSnow = int.Parse(Console.ReadLine());
     snowBallTime = int.Parse(Console.ReadLine());
     snowBallQuality = int.Parse(Console.ReadLine());
     snowBallSnowAndTime = (snowBallSnow / snowBallTime);
    snowBallFormula =BigInteger.Pow(snowBallSnowAndTime, snowBallQuality);
    if (snowBallFormula>bestSnowBall)
    {
        bestSnowBall = snowBallFormula;
        bestSnowBallSnow= snowBallSnow;
        bestSnowBallTime = snowBallTime;
        bestSnowBallQuality = snowBallQuality;

    }
}
Console.WriteLine($"{bestSnowBallSnow} : {bestSnowBallTime} = {bestSnowBall} ({bestSnowBallQuality})");

