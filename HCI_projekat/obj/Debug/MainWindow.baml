   M S B A M L   `   `   `  ????G  CHCI_projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HCI_projekatHCI_projekat  5   	       HCI_projekat.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:HCI_projekat     5   	   -   5          ? Title$  
MainWindow??5   	    ? SizeToContent$ WidthAndHeight=?6    ? WindowStyle$
 None=?6;    ? AllowsTransparency . 
?????? .??5	      ?? $
??1000??6   $	??650??6   .+?5
   
   F? -   5        $??UIPath??5
   1   
???????$??2??6   $	??650??6?    ?? Stretch$
 Fill=?6L   $
??1000??6[   ??5      ?? 5       ?? ImageSource$4 .C:\Users\Andjela\Desktop\faks\HCI\projekat.jpg??6   ??5      B? 5      .??5      E?  E? 
StartPoint$
 50,0&?6!   .??5      ??  ?? Size$ 50,50??6%    ?? RotationAngle$	 180Q?63   	 ?? 
IsLargeArc	 .  
 ?? SweepDirection$
 Counterclockwise=?6Z    ?? Point$
 0,50&?6|   ?? 5       ?? Point$ 0,400&?6&   ?? 5      $ 50,50??6%   $	 180Q?63   	 .  $
 Counterclockwise=?6Z   $ 50,450&?6|   ?? 5      $ 650,450&?6&   ?? 5      $ 50,50??6%   $	 180Q?62   	 .  $
 Counterclockwise=?6Y   $ 700, 400&?6{   ?? 5      $ 700,50&?6&   ?? 5      $ 50,50??6%   $	 180Q?63   	 .  $
 Counterclockwise=?6Z   $ 650,0&?6|   ?? 5      $  50, 0&?6&   5      5      5      ?? 5!   
   -   5         ??Name$ DugmeZatvori??5!      $??Zatvori??6'   $??25??69   $??70??6E    J? RenderTransformOrigin$ 12.27,17.064&?6P    ?? Left$	 880??6u   
 ?? Top$	 594??6?   6?   ?? 5"   
   -   5        $ 
DugmeDodaj??5"      $??Dodaj??6%   $??25??65   $??70??6A   $ 12.27,17.064&?6L   $	 760??6q   $	 594??6?   6?   &   System.Windows.Controls.DataGrid  5$   
   -   5        $??tabela??5$         CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .     CanUserResizeColumns .     CanUserReorderColumns .  
???????
?????? $	??500??6?   $	??900??6     
IsReadOnly .    AutoGenerateColumns .  $ 50??6@  $ 48??6Q  ??6!   ?? *uspesneZene+   Columns 5%      4  .System.Windows.Controls.DataGridTemplateColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      CellTemplate 5'      ?? 5(      .R?5)      ?? ??6$   ?? *Slika+5*      5,      0  *System.Windows.Controls.DataGridTextColumn  5.         Header$	 Ime??6&   $	 100 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ?? *Ime+6L     5/      $ Prezime??6&   $ 95 6S    67   ?? *	Prezime+6S     50      $ Broj nagrada??6&   $	 100 6\    6<   ?? *BrojNagrada+6\     51      $ Datum rodjenja??6&   $	 100 6X    6>   ?? *Datum+6X     55      $ * 6)    56      ?? 57      .R?58      ?? .+?59   "   ?? $ buttonOpsirnije??6)   -   5        $??	Opsirnije??59   B   6V   ?? 5:   "   $ buttonIzmeni??6)   -   5        $??Izmeni??5:   ?   6P   ?? 5;   "   $ buttonObrisi??6)   -   5        $??Obrisi??5;   ?   6P   5<      5=      5?      5A      5D      5E      