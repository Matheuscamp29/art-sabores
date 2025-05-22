import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { config } from './app/app.config.server';

process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0';

const bootstrap = () => bootstrapApplication(AppComponent, config);

export default bootstrap;
