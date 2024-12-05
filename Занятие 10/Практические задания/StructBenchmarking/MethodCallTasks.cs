using System;
using System.Runtime.CompilerServices;

#pragma warning disable 649

namespace StructBenchmarking;

public class MethodCallWithStructArgumentTask : ITask
{
	private readonly int size;

	private readonly S16 s16;
	private readonly S32 s32;
	private readonly S64 s64;
	private readonly S128 s128;
	private readonly S256 s256;
	private readonly S512 s512;

	public MethodCallWithStructArgumentTask(int size)
	{
		this.size = size;
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	public void Run()
	{
		switch (size)
		{
			case 16:
				PS16(s16);
				break;
			case 32:
				PS32(s32);
				break;
			case 64:
				PS64(s64);
				break;
			case 128:
				PS128(s128);
				break;
			case 256:
				PS256(s256);
				break;
			case 512:
				PS512(s512);
				break;
			default:
				throw new ArgumentException();
		}
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	void PS16(S16 o)
	{
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	void PS32(S32 o)
	{
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	void PS64(S64 o)
	{
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	void PS128(S128 o)
	{
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	void PS256(S256 o)
	{
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	void PS512(S512 o)
	{
	}
}


public class MethodCallWithClassArgumentTask : ITask
{
	private readonly int size;

	private readonly C16 c16;
	private readonly C32 c32;
	private readonly C64 c64;
	private readonly C128 c128;
	private readonly C256 c256;
	private readonly C512 c512;

	public MethodCallWithClassArgumentTask(int size)
	{
		this.size = size;
		c16 = new C16();
		c32 = new C32();
		c64 = new C64();
		c128 = new C128();
		c256 = new C256();
		c512 = new C512();
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	public void Run()
	{
		switch (size)
		{
			case 16:
				PC16(c16);
				break;
			case 32:
				PC32(c32);
				break;
			case 64:
				PC64(c64);
				break;
			case 128:
				PC128(c128);
				break;
			case 256:
				PC256(c256);
				break;
			case 512:
				PC512(c512);
				break;
			default:
				throw new ArgumentException();
		}
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	void PC16(C16 o)
	{
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	void PC32(C32 o)
	{
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	void PC64(C64 o)
	{
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	void PC128(C128 o)
	{
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	void PC256(C256 o)
	{
	}

	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	void PC512(C512 o)
	{
	}
}