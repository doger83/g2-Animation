﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using g2.Animation.Core.ParticleSystems;
using g2.Datastructures.Geometry;

namespace g2.Animation.Core.Benchmarks.ParticleSystems;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class ParticleBenchmarks
{
    private const int PARTICLESCOUNT = 1;
    private readonly Particle particle;
    private readonly Particle[] particles;

    public ParticleBenchmarks()
    {
        particle = new Particle(0, 0, 25, 25, new Quadrant(0, 0, 50, 50));
        particles = InitParticles(PARTICLESCOUNT);
    }

    private static Particle[] InitParticles(int number)
    {
        Particle[] particles = new Particle[number];
        for (int i = 0; i < number; i++)
        {
            particles[i] = new Particle(0, 0, 25, 25, new Quadrant(0, 0, 50, 50));
        }

        return particles;
    }

    [Benchmark(Baseline = true)]
    public void CheckBoundaries_basic()
    {
        for (int i = 0; i < PARTICLESCOUNT; i++)
        {
            particles[i].CheckBoundaries_basic();
        }
    }

    [Benchmark]
    public void CheckBoundaries_cachedInMethod()
    {
        for (int i = 0; i < PARTICLESCOUNT; i++)
        {
            particles[i].CheckBoundaries_cachedInMethod();
        }
    }

    [Benchmark]
    public void CheckBoundaries_basicWithFixedBounds()
    {
        for (int i = 0; i < PARTICLESCOUNT; i++)
        {
            particles[i].CheckBoundaries_basicWithFixedBounds();
        }
    }

    [Benchmark]
    public void CheckBoundaries_cachedInMethodWithFixedBoundsl()
    {
        for (int i = 0; i < PARTICLESCOUNT; i++)
        {
            particles[i].CheckBoundaries_cachedInMethodWithFixedBounds();
        }
    }

    [Benchmark]
    public void CheckBoundaries_cachedGlobal()
    {
        for (int i = 0; i < PARTICLESCOUNT; i++)
        {
            particles[i].CheckBoundaries_cachedGlobal();
        }
    }
}
