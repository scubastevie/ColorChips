using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    public class PathFinder
    {
        private List<ColorChip> colorChips;
        private List<ColorChip> longestPath;

        public PathFinder(List<ColorChip> colorChips)
        {
            this.colorChips = colorChips;
            longestPath = new List<ColorChip>();
        }

        public List<ColorChip> FindLongestPath(Color startColor, Color endColor)
        {
            List<ColorChip> currentPath = new List<ColorChip>();
            DFS(startColor, endColor, currentPath);
            if (longestPath.Count == 0)
            {
                throw new InvalidOperationException("No valid path exists.");
            }
            return longestPath;
        }

        private void DFS(Color currentColor, Color endColor, List<ColorChip> currentPath)
        {
            foreach (var chip in colorChips.Where(c => c.StartColor == currentColor))
            {
                if (!currentPath.Contains(chip))
                {
                    currentPath.Add(chip);

                    if (chip.EndColor == endColor)
                    {
                        // Update the longest path if the current path is longer
                        if (currentPath.Count > longestPath.Count)
                        {
                            longestPath = new List<ColorChip>(currentPath);
                        }
                    }
                    else
                    {
                        DFS(chip.EndColor, endColor, currentPath);
                    }

                    // Backtrack
                    currentPath.Remove(chip);
                }
            }
        }
    }
}
