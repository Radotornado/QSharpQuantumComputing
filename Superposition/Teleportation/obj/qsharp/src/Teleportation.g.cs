#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Quantum.Teleportation", "Teleport (msg : Qubit, there : Qubit) : ()", new string[] { }, "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Teleportation\\Teleportation.qs", 168L, 6L, 57L)]
#line hidden
namespace Quantum.Teleportation
{
    public class Teleport : Operation<(Qubit,Qubit), QVoid>
    {
        public Teleport(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Primitive.CNOT), typeof(Microsoft.Quantum.Primitive.H), typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.Release), typeof(Microsoft.Quantum.Primitive.X), typeof(Microsoft.Quantum.Primitive.Z) };
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

        protected IUnitary<(Qubit,Qubit)> MicrosoftQuantumPrimitiveCNOT
        {
            get
            {
                return this.Factory.Get<IUnitary<(Qubit,Qubit)>, Microsoft.Quantum.Primitive.CNOT>();
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

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.X>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveZ
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.Z>();
            }
        }

        public override Func<(Qubit,Qubit), QVoid> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.Teleportation.Teleport", OperationFunctor.Body, _args);
                var __result__ = default(QVoid);
                try
                {
                    var (msg,there) = _args;
#line 8 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Teleportation\\Teleportation.qs"
                    var register = Allocate.Apply(1L);
#line 9 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Teleportation\\Teleportation.qs"
                    var here = register[0L];
#line 10 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Teleportation\\Teleportation.qs"
                    MicrosoftQuantumPrimitiveH.Apply(here);
#line 11 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Teleportation\\Teleportation.qs"
                    MicrosoftQuantumPrimitiveCNOT.Apply((here, there));
#line 12 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Teleportation\\Teleportation.qs"
                    MicrosoftQuantumPrimitiveCNOT.Apply((msg, here));
#line 13 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Teleportation\\Teleportation.qs"
                    MicrosoftQuantumPrimitiveH.Apply(msg);
                    // Measure out the entanglement.
#line 15 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Teleportation\\Teleportation.qs"
                    if ((M.Apply<Result>(msg) == Result.One))
                    {
#line 15 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Teleportation\\Teleportation.qs"
                        MicrosoftQuantumPrimitiveZ.Apply(there);
                    }

#line 16 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Teleportation\\Teleportation.qs"
                    if ((M.Apply<Result>(here) == Result.One))
                    {
#line 16 "C:\\Users\\rado\\Documents\\GitHub\\QSharpQuantumComputing\\Superposition\\Teleportation\\Teleportation.qs"
                        MicrosoftQuantumPrimitiveX.Apply(there);
                    }

#line hidden
                    Release.Apply(register);
#line hidden
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.Teleportation.Teleport", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Qubit msg, Qubit there)
        {
            return __m__.Run<Teleport, (Qubit,Qubit), QVoid>((msg, there));
        }
    }
}