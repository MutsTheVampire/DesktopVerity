using System.Windows;
using System.Windows.Media.Media3D;

namespace DesktopVerity;

internal static class SphereGenerator
{
    /**
     * Generates a sphere model from a number of latitudinal and longitudinal bands.
     */
    public static MeshGeometry3D CreateSphere(int latitudeBands, int longitudeBands)
    {
        List<Point3D> vertices = [];
        List<Vector3D> normals = [];
        List<Point> textures = [];
        List<int> indices = [];

        const float radius = 1.0f;

        // Generate vertex positions, normals, and UVs from the bands.
        for (int lat = 0; lat <= latitudeBands; lat++)
        {
            double theta = Math.PI * -0.5 + Math.PI * lat / latitudeBands;
            double sinTheta = Math.Sin(theta);
            double cosTheta = Math.Cos(theta);

            for (int lon = 0; lon <= longitudeBands; lon++)
            {
                double phi = 2 * Math.PI * lon / longitudeBands;
                double sinPhi = Math.Sin(phi);
                double cosPhi = Math.Cos(phi);

                float x = (float)(radius * cosTheta * sinPhi);
                float y = (float)(radius * cosTheta * cosPhi);
                float z = (float)(radius * sinTheta);

                vertices.Add(new(x, y, z));
                normals.Add(new(x, y, z));

                float u = longitudeBands > 0 ? (float)(lon / (double)longitudeBands) : 0;
                float v = latitudeBands > 0 ? (float)((lat + 1) / (double)(latitudeBands + 2)) : 0;
                textures.Add(new(u, v));
            }
        }

        // Generate quads from the bands:
        for (int lat = 0; lat <  latitudeBands; lat++)
        {
            for (int lon = 0; lon < longitudeBands; lon++)
            {
                int first = lat * (longitudeBands + 1) + lon;
                int second = first + longitudeBands + 1;

                // First triangle:
                indices.Add(first);
                indices.Add(second);
                indices.Add(first + 1);

                // Second triangle:
                indices.Add(second);
                indices.Add(second + 1);
                indices.Add(first + 1);
            }
        }

        return new()
        {
            Positions = [.. vertices],
            Normals = [.. normals],
            TextureCoordinates = [.. textures],
            TriangleIndices = [.. indices],
        };
    }
}