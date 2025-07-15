namespace proyectcontacs
{
    class Contacto
    {
       public String name = "";
       public String phone = "";
       public String email = "";
       public String address = "";


        public Contacto(
        String name,
        String phone,
        String email,
        String address)
        {
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.address = address;
        }

        public Contacto()
        {
            
        }
    }

}