use FluxoCaixa;
db.createUser(
  {
    user: "teste",
    pwd: "1234",
    roles: [ { role: "readWrite", db: "FluxoCaixa" } ]
  }
);

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

db.createCollection("Receitas", {
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

db.getCollection("Receitas").createIndex({ "Nome": 1 });

db.Receitas.insertMany([{Nome: "Venda de Produto"}]);
db.Receitas.insertMany([{Nome: "Investimento"}]);
db.Receitas.insertMany([{Nome: "Aporte de Capital"}]);
db.Receitas.insertMany([{Nome: "Rendimento de Fundos"}]);

db.createCollection("RegistroDespesas", {
  validator: {
    bsonType: "object",
    required: ["DadaCadastro", "DataPagamento", "Status", "CodigoDespesa", "EstaAgendado"],
    properties: {
      DadaCadastro: {
        bsonType: "Date"
      },
	  DataPagamento: {
        bsonType: "Date"
      },
      EstaAgendado: {
        bsonType: "bool"
      },
      Status: {
        bsonType: "int"
      },
      CodigoDespesa: {
        bsonType: "int"
      }
    }
  },
  validationLevel: "moderate",
  validationAction: "warn"
});

db.getCollection("RegistroDespesas").createIndex({ "DadaCadastro": 1 });
db.getCollection("RegistroDespesas").createIndex({ "DataPagamento": 1 });
db.getCollection("RegistroDespesas").createIndex({ "Status": 1 });

db.createCollection("RegistroReceitas", {
  validator: {
    bsonType: "object",
    required: ["DadaCadastro", "DataPagamento", "Status", "CodigoReceita", "EstaAgendado"],
    properties: {
      DadaCadastro: {
        bsonType: "Date"
      },
	  DataPagamento: {
        bsonType: "Date"
      },
      EstaAgendado: {
        bsonType: "bool"
      },
      Status: {
        bsonType: "int"
      },
      CodigoReceita: {
        bsonType: "int"
      }
    }
  },
  validationLevel: "moderate",
  validationAction: "warn"
});

db.getCollection("RegistroReceitas").createIndex({ "CodigoReceita": 1 });
db.getCollection("RegistroReceitas").createIndex({ "DadaCadastro": 1 });
db.getCollection("RegistroReceitas").createIndex({ "DataPagamento": 1 });
db.getCollection("RegistroReceitas").createIndex({ "Status": 1 });
