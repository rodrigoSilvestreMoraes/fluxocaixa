db.createCollection("Clientes", {
  validator: {
    bsonType: "object",
    required: ["Nome"],
    properties: {
      Nome: {
        bsonType: "string"
      }
    }
  },
  validationLevel: "moderate",
  validationAction: "warn"
});

db.getCollection("Clientes").createIndex({ "Nome": 1 });

db.Clientes.insertMany([{Nome: "Coca Cola"}]);
db.Clientes.insertMany([{Nome: "CBL Advogados"}]);
db.Clientes.insertMany([{Nome: "Casa da Panqueca"}]);
db.Clientes.insertMany([{Nome: "Pizzaria Altas Horas"}]);
db.Clientes.insertMany([{Nome: "Hospital Samaritano"}]);