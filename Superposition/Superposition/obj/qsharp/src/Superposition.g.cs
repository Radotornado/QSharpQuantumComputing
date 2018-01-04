#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Quantum.Superposition", "Set (desired : Result, q1 : Qubit) : ()", new string[] { }, "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs", 134L, 6L, 5L)]
[assembly: OperationDeclaration("Quantum.Superposition", "SuperpositionTest (count : Int, initial : Result) : (Int, Int)", new string[] { }, "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs", 377L, 19L, 5L)]
#line hidden
namespace Quantum.Superposition
{
    public class Set : Operation<(Result,Qubit), QVoid>
    {
        public Set(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.X) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.X>();
            }
        }

        public override Func<(Result,Qubit), QVoid> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.Superposition.Set", OperationFunctor.Body, _args);
                var __result__ = default(QVoid);
                try
                {
                    var (desired,q1) = _args;
#line 9 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs"
                    var current = M.Apply<Result>(q1);
#line 11 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs"
                    if ((desired != current))
                    {
#line 13 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs"
                        MicrosoftQuantumPrimitiveX.Apply(q1);
                    }

#line hidden
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.Superposition.Set", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Result desired, Qubit q1)
        {
            return __m__.Run<Set, (Result,Qubit), QVoid>((desired, q1));
        }
    }

    public class SuperpositionTest : Operation<(Int64,Result), (Int64,Int64)>
    {
        public SuperpositionTest(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Primitive.H), typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.Release), typeof(Quantum.Superposition.Set) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected Allocate Allocate
        {
            get
            {
                return this.Factory.Get<Allocate, Microsoft.Quantum.Primitive.Allocate>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.H>();
            }
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected Release Release
        {
            get
            {
                return this.Factory.Get<Release, Microsoft.Quantum.Primitive.Release>();
            }
        }

        protected ICallable<(Result,Qubit), QVoid> Set
        {
            get
            {
                return this.Factory.Get<ICallable<(Result,Qubit), QVoid>, Quantum.Superposition.Set>();
            }
        }

        public override Func<(Int64,Result), (Int64,Int64)> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.Superposition.SuperpositionTest", OperationFunctor.Body, _args);
                var __result__ = default((Int64,Int64));
                try
                {
                    var (count,initial) = _args;
#line 22 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs"
                    var numOnes = 0L;
#line 23 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs"
                    var qubits = Allocate.Apply(1L);
#line 26 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs"
                    foreach (var test in new Range(1L, count))
                    {
#line 28 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs"
                        Set.Apply((initial, qubits[0L]));
                        // Set Qubit to superposition 
#line 31 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs"
                        MicrosoftQuantumPrimitiveH.Apply(qubits[0L]);
#line 32 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs"
                        var res = M.Apply<Result>(qubits[0L]);
                        // Count the number of ones we saw:
#line 34 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs"
                        if ((res == Result.One))
                        {
#line 36 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs"
                            numOnes = (numOnes + 1L);
                        }
                    }

#line 40 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs"
                    Set.Apply((Result.Zero, qubits[0L]));
#line hidden
                    Release.Apply(qubits);
#line hidden
                    __result__ = ((count - numOnes), numOnes);
                    // Return number of times we saw a |0> and number of times we saw a |1>
#line 44 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Superposition\\Superposition.qs"
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.Superposition.SuperpositionTest", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<(Int64,Int64)> Run(IOperationFactory __m__, Int64 count, Result initial)
        {
            return __m__.Run<SuperpositionTest, (Int64,Result), (Int64,Int64)>((count, initial));
        }
    }
}