/**
 * bits 100%
 * Runtime: 91 ms
 * Memory Usage: 48 MB
 */

public class Solution {
    public class PairHash<T> : IEqualityComparer<Tuple<T, T>> {
        public bool Equals(Tuple<T, T> x, Tuple<T, T> y) {
            return x.Item1.Equals(y.Item1) && x.Item2.Equals(y.Item2);
        }

        public int GetHashCode(Tuple<T, T> obj) {
            long seed = 0;
            seed ^= obj.Item1.GetHashCode() + 0x9e3779b9 + (seed << 6) + (seed >> 2);
            seed ^= obj.Item2.GetHashCode() + 0x9e3779b9 + (seed << 6) + (seed >> 2);
            return (int)seed;
        }
    }

    public int MinPushBox(char[][] grid) {
        Tuple<int, int> b = null, p = null, t = null;
        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid[0].Length; ++j) {
                if (grid[i][j] == 'B') {
                    b = Tuple.Create(i, j);
                } else if (grid[i][j] == 'S') {
                    p = Tuple.Create(i, j);
                } else if (grid[i][j] == 'T') {
                    t = Tuple.Create(i, j);
                }
            }
        }
        return AStar(grid, b, p, t);
    }

    private int AStar(char[][] grid, Tuple<int, int> b, Tuple<int, int> p, Tuple<int, int> t) {
        int f = G(b, t), dh = 2;
        var closer = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>() { Tuple.Create(b, p) };
        var detour = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();
        var lookup = new HashSet<Tuple<int, int>>(new PairHash<int>());
        while (closer.Count > 0 || detour.Count > 0) {
            if (closer.Count == 0) {
                f += dh;
                closer = detour;
                detour = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();
            }
            var (currentB, currentP) = closer[closer.Count - 1];
            closer.RemoveAt(closer.Count - 1);
            if (currentB.Equals(t)) {
                return f;
            }
            if (lookup.Contains(Tuple.Create(currentB.Item1 * grid[0].Length + currentB.Item2,
                                             currentP.Item1 * grid[0].Length + currentP.Item2))) {
                continue;
            }
            lookup.Add(Tuple.Create(currentB.Item1 * grid[0].Length + currentB.Item2,
                                    currentP.Item1 * grid[0].Length + currentP.Item2));
            foreach (var (dx, dy) in directions) {
                var nb = Tuple.Create(currentB.Item1 + dx, currentB.Item2 + dy);
                var np = Tuple.Create(currentB.Item1 - dx, currentB.Item2 - dy);
                if (!(0 <= nb.Item1 && nb.Item1 < grid.Length &&
                      0 <= nb.Item2 && nb.Item2 < grid[0].Length &&
                      0 <= np.Item1 && np.Item1 < grid.Length &&
                      0 <= np.Item2 && np.Item2 < grid[0].Length &&
                      grid[nb.Item1][nb.Item2] != '#' && grid[np.Item1][np.Item2] != '#' &&
                      !lookup.Contains(Tuple.Create(nb.Item1 * grid[0].Length + nb.Item2,
                                                    currentB.Item1 * grid[0].Length + currentB.Item2)) &&
                      CanReach(grid, currentB, currentP, np))) {
                    continue;
                }
                if (Dot(Tuple.Create(dx, dy), Tuple.Create(t.Item1 - currentB.Item1, t.Item2 - currentB.Item2)) > 0) {
                    closer.Add(Tuple.Create(nb, currentB));
                } else {
                    detour.Add(Tuple.Create(nb, currentB));
                }
            }
        }
        return -1;
    }

    private int G(Tuple<int, int> a, Tuple<int, int> b) {
        return Math.Abs(a.Item1 - b.Item1) + Math.Abs(a.Item2 - b.Item2);
    }

    private bool CanReach(char[][] grid, Tuple<int, int> b, Tuple<int, int> p, Tuple<int, int> t) {
        var closer = new List<Tuple<int, int>>() { p };
        var detour = new List<Tuple<int, int>>();
        var lookup = new HashSet<int>() { b.Item1 * grid[0].Length + b.Item2 };
        while (closer.Count > 0 || detour.Count > 0) {
            if (closer.Count == 0) {
                closer = detour;
                detour = new List<Tuple<int, int>>();
            }
            var currentP = closer[closer.Count - 1];
            closer.RemoveAt(closer.Count - 1);
            if (currentP.Equals(t)) {
                return true;
            }
            if (lookup.Contains(currentP.Item1 * grid[0].Length + currentP.Item2)) {
                continue;
            }
            lookup.Add(currentP.Item1 * grid[0].Length + currentP.Item2);
            foreach (var (dx, dy) in directions) {
                var np = Tuple.Create(currentP.Item1 + dx, currentP.Item2 + dy);
                if (!(0 <= np.Item1 && np.Item1 < grid.Length &&
                      0 <= np.Item2 && np.Item2 < grid[0].Length &&
                      grid[np.Item1][np.Item2] != '#' &&
                      !lookup.Contains(np.Item1 * grid[0].Length + np.Item2))) {
                    continue;
                }
                if (Dot(Tuple.Create(dx, dy), Tuple.Create(t.Item1 - currentP.Item1, t.Item2 - currentP.Item2)) > 0) {
                    closer.Add(np);
                } else {
                    detour.Add(np);
                }
            }
        }
        return false;
    }

    private int Dot(Tuple<int, int> a, Tuple<int, int> b) {
        return a.Item1 * b.Item1 + a.Item2 * b.Item2;
    }

    private static readonly List<Tuple<int, int>> directions = new List<Tuple<int, int>> {
        Tuple.Create(0, 1), Tuple.Create(1, 0), Tuple.Create(0, -1), Tuple.Create(-1, 0)
    };
}
