28/10/2020
Completar atributos para:
	- Alquiler (Hecho)
	- AlquilerDeAccesorios (Hecho)
	- Pago (Hecho)

Completar con los display para el Entity:
	- Todas las clases (Hecho 29/10)

(Ejemplo de display:
	[Display(Name = "Fecha inscripción")]
	public DateTime FechaInscripto { get; set; }
)

--------------------------------------------------------------------------------------
29/10/2020
Nico:	Agregué los display a todos los campos, deberíamos chequear que este bien eso. (Clases modificadas: todas menos enums)
		Agregué también un comentario "//Este atributo es una clave foránea a la tabla <<tabla>>" en cada FK
		Le deberiamos consultar al profe lo de las FK y para proteger el campo "contraseña" en Usuario

