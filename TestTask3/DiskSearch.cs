namespace TestTask3;

public class DiskSearch
{
    public int[] Search(int[] disks, int currentDisk)
    {
        int[] result = new int[0];
        for (int i = 0; i < disks.Length; i++)
        {
            if (disks[i] == currentDisk)
            {
                result = new int[1];
                result[0] = disks[i];
                return result;
            }
        }
        for (int i = 0; i < disks.Length; i++)
        {
            
            for (int k = i + 1; k < disks.Length; k++)
            {
                if (disks[i] + disks[k] == currentDisk)
                {
                    result = new int[2];
                    result[0] = disks[i];
                    result[1] = disks[k];
                    return result;
                }
            }
        }
        return result;
    }
}
