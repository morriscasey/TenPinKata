namespace TenPinBowling;

public class TenPinBowlingGame
{
    public static int Score(string line)
    {
        int[] input = line.Split(' ')
            .Select(text => int.Parse(text))
            .ToArray();

        int totalScore = 0;

        // First 9 frames the even index is the first roll and the odd index is the second roll
        // The 10th frame is a special case where you could have 3 rolls if you get a strike or a spare
        for (int index = 0; index < input.Length; index++)
        { 
            int frameScore = input[index];  // first roll

            
            if (frameScore == 10 && index +2 < input.Length) // Strike add the next two rolls
            {
                frameScore += input[index + 1] + input[index + 2];
            }
            else if (index + 2 < input.Length && frameScore + input[index + 1] == 10)  // Spare add the next roll
            {
                frameScore += input[index + 1];     // second roll
                frameScore += input[index + 2];     // third roll
                index++; // Skip next throw
            }

            totalScore += frameScore;
        }

        return totalScore;
    }
}
