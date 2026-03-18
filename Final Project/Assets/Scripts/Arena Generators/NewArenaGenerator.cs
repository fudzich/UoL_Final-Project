using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewArenaGenerator : MonoBehaviour
{
    public class Cell
    {
        public bool visited = false;
        public bool[] status = new bool[3];
        public int element; // 0: Earth, 1: Fire, 2: Nature, 3: Water
    }

    public Vector2 size;
    public int startPos = 0;
    public GameObject[] tiles; // Assumed ordered as: Earth, Fire, Nature, Water
    public Vector2 offset;

    List<Cell> board;

    void Start()
    {
        PathGenerator();
    }

    void GenerateArena()
    {
        int previousTile = Random.Range(0, tiles.Length);
        int randomTile;

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                int cellIndex = Mathf.FloorToInt(i + j * size.x);
                int elementType = board[cellIndex].element;

                // Select prefab based on element
                GameObject tilePrefab = tiles[elementType];

                // Randomly choose tile variation
                if (Random.Range(0, 2) == 0)
                    randomTile = Random.Range(0, tiles.Length);
                else
                    randomTile = previousTile;

                var newTile = Instantiate(tilePrefab, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform);
                newTile.GetComponent<TileBehaviour>().UpdateTile(board[cellIndex].status);
                newTile.name += $" {i} {j}";

                previousTile = randomTile;
            }
        }
    }

    void PathGenerator()
    {
        board = new List<Cell>();

        // Initialize the board
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
            }
        }

        int currentCell = startPos;
        // Assign initial element randomly
        board[currentCell].element = Random.Range(0, 4);
        board[currentCell].visited = true;

        Stack<int> path = new Stack<int>();
        int k = 0;

        while (k < 10000)
        {
            k++;
            board[currentCell].visited = true;

            List<int> neighbors = CheckNeighbours(currentCell);

            if (neighbors.Count == 0)
            {
                if (path.Count == 0)
                    break;
                else
                {
                    currentCell = path.Pop();
                }
            }
            else
            {
                path.Push(currentCell);

                int newCell = neighbors[Random.Range(0, neighbors.Count)];

                // Count neighbors' elements
                Dictionary<int, int> elementCounts = new Dictionary<int, int> {
                    {0, 0},
                    {1, 0},
                    {2, 0},
                    {3, 0}
                };

                foreach (int neighbor in CheckNeighbours(newCell))
                {
                    int neighborElement = board[neighbor].element;
                    elementCounts[neighborElement]++;
                }

                // Bias towards less represented elements to promote diversity
                // Calculate inverse counts for biasing
                int totalBiasWeight = 0;
                Dictionary<int, int> biasWeights = new Dictionary<int, int>();

                foreach (var kvp in elementCounts)
                {
                    // To favor less common, invert counts; add 1 to avoid division by zero
                    int weight = 1 + (5 - kvp.Value); // or use (maxCount - count + 1)
                    biasWeights[kvp.Key] = weight;
                    totalBiasWeight += weight;
                }

                // Select element based on bias weights
                int rand = Random.Range(0, totalBiasWeight);
                int cumulative = 0;
                int selectedElement = 0;

                foreach (var kvp in biasWeights)
                {
                    cumulative += kvp.Value;
                    if (rand < cumulative)
                    {
                        selectedElement = kvp.Key;
                        break;
                    }
                }

                board[newCell].element = selectedElement;

                // Assign random tower to current cell before moving
                int towerNumber = Random.Range(0, 3);
                board[currentCell].status[towerNumber] = true;

                currentCell = newCell;
            }
        }

        GenerateArena();
    }

    List<int> CheckNeighbours(int cell)
    {
        List<int> neighbors = new List<int>();

        int width = (int)size.x;
        int height = (int)size.y;

        // Up
        if (cell - width >= 0 && !board[Mathf.FloorToInt(cell - width)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - width));
        }
        // Down
        if (cell + width < board.Count && !board[Mathf.FloorToInt(cell + width)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + width));
        }
        // Right
        if ((cell + 1) % width != 0 && !board[Mathf.FloorToInt(cell + 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }
        // Left
        if (cell % width != 0 && !board[Mathf.FloorToInt(cell - 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }

        return neighbors;
    }
}