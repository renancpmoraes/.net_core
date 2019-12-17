import { Lote } from './Lote';
import { RedeSocial } from './RedeSocial';
import { Palestrante } from './Palestrante';

export interface Evento {

         id: number;
         local: string;
         dataEvento: Date;
         tema: string;
<<<<<<< HEAD
         qtdPessoas: number;
=======
         ttdPessoas: number;
>>>>>>> 632e3441ccc19ae84d302f92ee16af5dbfce4585
         imagemURL: string;
         telefone: string;
         email: string;
         lotes: Lote[];
         redesSociais: RedeSocial[];
         palestrantesEventos: Palestrante[];
}
