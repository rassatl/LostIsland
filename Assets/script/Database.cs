using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npgsql;
using UnityEngine.SceneManagement;

public class Database : MonoBehaviour
{
    
    public static NpgsqlConnection con;
    public static bool connected = false;
    public static string iduser;
    // Start is called before the first frame update
    void Start()
    {
        string cs = "Host=beta.asivity.fr;Username=asivity;Password='9=jM;B<22b/DOIi`';Database=postgres";
        con = new NpgsqlConnection(cs);
        con.Open();
    }

    public void Log(string id,string password)
    {
        var cmd = new NpgsqlCommand($"Select count(*) from users where username='{id}' and password=md5('{password}')", con);
        var version = cmd.ExecuteScalar().ToString();
        if (version == "0")
        {
            var insert = new NpgsqlCommand($"insert into users (username,password) values ('{id}',md5('{password}'))", con);
            insert.ExecuteScalar();
        }
        connected = true;
        iduser = new NpgsqlCommand($"Select userid from users where username='{id}' and password=md5('{password}')", con).ExecuteScalar().ToString();
    }
    public static void Get(Player p)
    {
        var cmd = new NpgsqlCommand($"Select * from saves where userid={iduser}", con);
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Player pl = p.GetComponent<Player>();
                SceneManager.LoadScene(reader.GetString(20));
                pl.pv = reader.GetInt32(2);
                pl.xp = reader.GetInt32(3);
                pl.nage = reader.GetInt32(4);
                pl.escalade = reader.GetInt32(5);
                pl.maitreDuFeu = reader.GetInt32(6);
                pl.architecte = reader.GetInt32(7);
                pl.nbPouletCru = reader.GetInt32(8);
                pl.nbPouletCuit = reader.GetInt32(9);
                pl.nbSilex = reader.GetInt32(10);
                pl.nbOs = reader.GetInt32(11);
                pl.harpon = reader.GetBoolean(12);
                pl.goldCigare = reader.GetBoolean(13);
                string arbres = reader.GetString(14);
                string boolarbres = "";
                foreach (char c in arbres)
                    if (c == 'f' || c == 't')
                        boolarbres += c;
                for (int i = 0; i < boolarbres.Length; i++)
                    p.GetComponent<persistenceScene>().listArbreScene1[i] = boolarbres[i] == 't' ? true : false;
                p.GetComponent<persistenceScene>().rocherScene3 = reader.GetBoolean(15);
                string[] position = reader.GetString(16).Replace('{', ' ').Replace('}', ' ').Split(';');
                p.transform.position = new Vector3(float.Parse(position[0]), float.Parse(position[1]), float.Parse(position[2]));
                string[] orientation = reader.GetString(17).Replace('{', ' ').Replace('}', ' ').Split(';');
                p.transform.rotation = new Quaternion(float.Parse(orientation[0]), float.Parse(orientation[1]), float.Parse(orientation[2]), float.Parse(orientation[3]));
            }
        }
        
        cmd = new NpgsqlCommand($"Select * from missions where userid={iduser}", con);
        using (var reader2 = cmd.ExecuteReader())
        {
            while (reader2.Read())
            {
                for (int i = 0; i < GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().listeTaches.Count; i++)
                {
                    GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().listeTaches[i].Affiche = reader2.GetString(i+1)[0] == 't';
                    GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().listeTaches[i].Fait = reader2.GetString(i+1)[1] == 't';
                }
                
            }
            
        }
        
    }
    public static void Set(Player p)
    {
        p = p.GetComponent<Player>();
        persistenceScene ps = p.GetComponent<persistenceScene>();
        string arbres = "{";
        for (int i = 0; i < ps.listArbreScene1.Count; i++)
        {
            arbres += ps.listArbreScene1[i] ? "t" : "f";
            if (i == ps.listArbreScene1.Count - 1)
                arbres += "}";
            else
                arbres += ",";
        }
        string position = "'{" + $"{System.Math.Round(p.transform.position.x, 2)};{System.Math.Round(p.transform.position.y, 2)};{System.Math.Round(p.transform.position.z, 2)}" + "}'";
        string lastposition = "'{" + $"{System.Math.Round(Player.lastSpawnPos.x,2)};{System.Math.Round(Player.lastSpawnPos.y,2)};{System.Math.Round(Player.lastSpawnPos.z,2)}" + "}'";
        string orientation = "'{" + $"{System.Math.Round(p.transform.rotation.x, 2)};{System.Math.Round(p.transform.rotation.y, 2)};{System.Math.Round(p.transform.rotation.z, 2)};{System.Math.Round(p.transform.rotation.w, 2)}" + "}'";
        string lastorientation = "'{" + $"{System.Math.Round(Player.lastSpawnRot.x, 2)};{System.Math.Round(Player.lastSpawnRot.y, 2)};{System.Math.Round(Player.lastSpawnRot.z, 2)};{System.Math.Round(Player.lastSpawnRot.w, 2)}" + "}'";
        var cmd = new NpgsqlCommand($"Update saves set pv={p.pv} , xp={p.xp} , nage={p.nage} , escalade={p.escalade} , maitredufeu={p.maitreDuFeu} , architecte={p.architecte} , nbpouletcru={p.nbPouletCru} , nbpouletcuit={p.nbPouletCuit} , nbsilex={p.nbSilex} , nbos={p.nbOs} , harpon={p.harpon} , goldcigare={p.goldCigare} , arbres='{arbres}' , position={position}, lastposition={lastposition} , rocher={ps.rocherScene3},lastorientation={lastorientation}  , orientation={orientation} , scene='{SceneManager.GetActiveScene().name}' where userid={iduser}", con);
        cmd.ExecuteScalar();
        string missionsQuerry = "update missions set ";
        List<Tache> taches = GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().listeTaches;
        foreach (Tache t in taches)
        {
            missionsQuerry += $"\"{t.Name}\"= '{(t.Affiche ? "t" : "f") + (t.Fait ? "t" : "f")}'";
            if (t.Name != "Ecrire SOS avec des rochers")
                missionsQuerry += ", ";
        }
        missionsQuerry += $" where userid={iduser}";
        var querry = new NpgsqlCommand(missionsQuerry, con);
        querry.ExecuteScalar();
    }
}
