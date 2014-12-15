﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace ccd
{
    public static class DatabaseWorker
    {
        private const string _connectionString = @"server=.\SQL_EXPRESS_2012;Database=CCD;Integrated Security=SSPI;";

        public static Card GetCardById(Guid cardId)
        {
            var card = new Card();
            using (var myConnection = new SqlConnection(_connectionString))
            {
                string oString = "select * from [card] where card_id = @cardId";
                var oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@cardId", cardId);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        card.Name = oReader["card_name"].ToString();
                        card.Hp = (int)oReader["card_hp"];
                        card.Atk = (int)oReader["card_atk"];
                        card.Rang = (int) oReader["card_rang"];
                        card.SpecialType = (CardSpecType) oReader["card_special_type"];
                        card.SpecialValue = (int) oReader["card_special_value"];
                        card.Type = (CardType) oReader["cardType"];
                    }

                    myConnection.Close();
                }
            }
            return card;
        }

        public static Card CreateCard(Card newCard)
        {
            using (var myConnection = new SqlConnection(_connectionString))
            {
                string oString = "insert into [card] values (@id, @name, @hp, @atk, @rang, @specType, @specValue, @type)";
                var oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                oCmd.Parameters.AddWithValue("@name", newCard.Name);
                oCmd.Parameters.AddWithValue("@hp", newCard.Hp);
                oCmd.Parameters.AddWithValue("@atk", newCard.Atk);
                oCmd.Parameters.AddWithValue("@rang", newCard.Rang);
                oCmd.Parameters.AddWithValue("@specType", (int)newCard.SpecialType);
                oCmd.Parameters.AddWithValue("@specValue", newCard.SpecialValue);
                oCmd.Parameters.AddWithValue("@type", (int)newCard.Type);
                myConnection.Open();
                oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return newCard;
        }
    }
}
