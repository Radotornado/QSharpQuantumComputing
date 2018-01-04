namespace Quantum.Teleportation
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

    operation Teleport(msg : Qubit, there : Qubit) : () {
		body {
			using (register = Qubit[1]) {
				let here = register[0];
				H(here);
				CNOT(here, there);
				CNOT(msg, here);
				H(msg);
				 // Measure out the entanglement.
				if (M(msg) == One)  { Z(there); }
				if (M(here) == One) { X(there); }
			}
		}
	}
}
