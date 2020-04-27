import Vue from 'vue';
import Vuetify from 'vuetify/lib';

Vue.use(Vuetify);

const vuetify = new Vuetify({
    theme: {
        dark: true,
        themes: {
            dark: {
                primary: '#88bdbc',
                secondary: '#254E58',
                accent: '#112D32',
                error: '#4F4A41',
                anchor: '#254e58'
            },
            light: {
                    primary: '#88bdbc',
                    secondary: '#254E58',
                    accent: '#112D32',
                    error: '#4F4A41'
                
            }
        }
    }
})

export default vuetify
