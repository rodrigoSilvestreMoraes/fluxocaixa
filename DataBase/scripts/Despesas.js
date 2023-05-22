db.createCollection("Despesas", {
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

db.getCollection("Despesas").createIndex({ "Nome": 1 });

db.Despesas.insertMany([{Nome: "Sálarios"}]);
db.Despesas.insertMany([{Nome: "Compra de remessa de tapetes"}]);
db.Despesas.insertMany([{Nome: "Limpeza mensal do escritório"}]);
db.Despesas.insertMany([{Nome: "Benefícios"}]);
