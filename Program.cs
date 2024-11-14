namespace NumberOfIslands
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int numIslands = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        numIslands++;
                        //DFS(grid, i, j);
                        IterativeDFS(grid, i, j);
                    }
                }
            }

            return numIslands;

        }

        //This DFS is causing stack overflow for large grids.
        private void DFS(char[][] grid, int i, int j)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            //Check boundries and if current cell is water
            if (i < 0 || j < 0 || i >= rows || j >= cols || grid[i][j] == 0)
            {
                return;
            }

            //Make current cell as visited
            grid[i][j] = '0';

            //Visit all the adjacent cells(up, down, left, right)
            DFS(grid, i - 1, j);
            DFS(grid, i + 1, j);
            DFS(grid, i, j - 1);
            DFS(grid, i, j + 1);

        }

        private void IterativeDFS(char[][] grid, int startRow, int startCol)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            //Use stack to stimulate the recursive DFS
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((startRow, startCol));
            grid[startRow][startCol] = '0'; //Mark as visited

            //Directions array for moving up, down, left, right
            int[][] directions = new int[][] {
            new int[] {-1, 0},      //up
            new int[] {1, 0},       //down
            new int[] {0, -1},      //left
            new int[] {0, 1}        //right
        };

            while (stack.Count > 0)
            {
                var (currentRow, currentCol) = stack.Pop();

                //Check all four possible dicrections
                foreach (var direction in directions)
                {
                    int newRow = currentRow + direction[0];
                    int newCol = currentCol + direction[1];

                    //Check boundries
                    if (newRow >= 0 && newCol >= 0 && newRow < rows && newCol < cols && grid[newRow][newCol] == '1')
                    {
                        stack.Push((newRow, newCol));
                        grid[newRow][newCol] = '0';     //Mark as visited. 
                    }
                }
            }

        }
    }
}
