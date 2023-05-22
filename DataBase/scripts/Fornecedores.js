db.createCollection("Fornecedores", {
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

db.getCollection("Fornecedores").createIndex({ "Nome": 1 });

db.Fornecedores.insertMany([{Nome: "Papelaria Central"}]);
db.Fornecedores.insertMany([{Nome: "CIA do Plástico"}]);
db.Fornecedores.insertMany([{Nome: "Clean All, Empresa de Limpeza"}]);
db.Fornecedores.insertMany([{Nome: "China Import"}]);
